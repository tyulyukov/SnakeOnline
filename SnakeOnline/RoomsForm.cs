using SnakeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class RoomsForm : Form
    {
        private Client client;

        private MouseController mouse;
        private WindowController window;

        private String Nickname;

        public RoomsForm(String nickname)
        {
            InitializeComponent();

            mouse = new MouseController();
            window = new WindowController(this);

            Nickname = nickname;

            Shown += RoomsForm_Load;
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            try 
            {
                var enterIPEndPoint = new EnterServerIPEndPoint();
                if (enterIPEndPoint.ShowDialog() == DialogResult.OK)
                {
                    client = new Client(enterIPEndPoint.Ip, enterIPEndPoint.Port);
                    client.Nickname = Nickname;

                    client.Connect();

                    client.Send(new ClientPacket(ClientPacketType.IsNicknameExisting, client.Nickname, "Check my nickname on existense"));
                    var packet = client.Receive();

                    if (packet.Type != ServerPacketType.Success)
                    {
                        if (client.IsConnected)
                            client.Disconnect();

                        CustomizedMessageBox.Show("This nickname is already taken");

                        FormClosing -= RoomsForm_FormClosing;
                        Close();
                    }
                    else
                    {
                        LoadRooms();
                    }
                }
                else
                {
                    FormClosing -= RoomsForm_FormClosing;
                    Close();
                }
            }
            catch 
            {
                CustomizedMessageBox.Show("Failed to establish connection with the server"); 
                FormClosing -= RoomsForm_FormClosing; 
                Close(); 
            }
            
        }

        #region Window Control

        private void panelAppMenu_MouseDown(object sender, MouseEventArgs e) => mouse.Push();

        private void panelAppMenu_MouseUp(object sender, MouseEventArgs e) => mouse.Push();

        private void panelAppMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouse.IsPushed)
                return;

            if (mouse.Distance == Point.Empty)
                mouse.SetDistance(e.Location);

            SetDesktopLocation(MousePosition.X - mouse.Distance.X, MousePosition.Y - mouse.Distance.Y);
        }

        private void buttonCloseApp_Click(object sender, EventArgs e) => window.Close();

        private void buttonMaximizeApp_Click(object sender, EventArgs e)
        {
            if (window.Normalized)
                window.Maximize();
            else
                window.Normalize();
        }

        private void buttonMinimizeApp_Click(object sender, EventArgs e) => window.Minimize();

        private void buttonCloseApp_MouseEnter(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Red;

        private void buttonCloseApp_MouseLeave(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Empty;

        private void buttonMinOrMax_MouseEnter(object sender, EventArgs e) => (sender as PictureBox).BackColor = Color.Gray;

        private void buttonMinOrMax_MouseLeave(object sender, EventArgs e) => (sender as PictureBox).BackColor = Color.Empty;


        #endregion

        private void RoomsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
                client.Disconnect();

            Application.Exit();
        }

        private void LoadRooms()
        {
            panelRooms.Controls.Clear();

            try
            {
                client.Send(new ClientPacket(ClientPacketType.GetRooms, client.Nickname, "Request to load rooms to client"));
                var packet = client.Receive();

                if (packet == null)
                    return;

                if (packet.Type == ServerPacketType.Error)
                {
                    CustomizedMessageBox.Show("Failed to load rooms from server");
                    return;
                }

                var loadedRooms = packet.Parameter as ICollection<Room>;

                foreach (Room room in loadedRooms)
                {
                    var presenter = new RoomPresenter(room);
                    presenter.OnButtonJoinClick += buttonJoin_Click;
                    panelRooms.Controls.Add(presenter.Present());
                }
            }
            catch
            {
                CustomizedMessageBox.Show("Failed to establish connection with the server");
                return;
            }
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            String roomId = (sender as Button).Tag.ToString();
            try
            {
                client.Send(new ClientPacket(ClientPacketType.JoinRoom, client.Nickname, roomId));
                var packet = client.Receive();

                if (packet.Type == ServerPacketType.Error)
                {
                    CustomizedMessageBox.Show(packet.Message);
                    return;
                }

                var room = packet.Parameter as Room;

                Hide();
                new PlayersWaitingForm(client, room, false).ShowDialog();
                Show();
            }
            catch
            {
                CustomizedMessageBox.Show("Failed to establish connection with the server");
                return;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e) => LoadRooms();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var roomCreatingForm = new RoomCreatingForm();
            if (roomCreatingForm.ShowDialog() == DialogResult.OK)
            {
                Room newRoom = new Room(roomCreatingForm.RoomName, client.Nickname, roomCreatingForm.Count);

                try
                {
                    client.Send(new ClientPacket(ClientPacketType.CreateRoom, client.Nickname, $"Create new room <{newRoom.Name}>", newRoom));
                    var packet = client.Receive();

                    if (packet == null)
                        return;

                    if (packet.Type == ServerPacketType.Error)
                    {
                        CustomizedMessageBox.Show("Failed to create room");
                        return;
                    }

                    client.Send(new ClientPacket(ClientPacketType.JoinRoom, client.Nickname, newRoom.Id.ToString()));
                    packet = client.Receive();

                    if (packet.Type == ServerPacketType.Error)
                    {
                        CustomizedMessageBox.Show(packet.Message);
                        return;
                    }

                    newRoom = packet.Parameter as Room;
                }
                catch
                {
                    CustomizedMessageBox.Show("Failed to establish connection with the server");
                    return;
                }

                Hide();
                new PlayersWaitingForm(client, newRoom, true).ShowDialog();
                Show();
            }
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (client.IsConnected)
                client.Disconnect();

            FormClosing -= RoomsForm_FormClosing;
            Close();
        }
    }
}

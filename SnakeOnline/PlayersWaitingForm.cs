using SnakeLibrary;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class PlayersWaitingForm : Form
    {
        private Client client;

        private Room room;

        private WindowController window;
        private MouseController mouse;
        private SynchronizationContext ui;

        private readonly bool isCreator;

        private bool acceptUpdates = true;

        public PlayersWaitingForm(Client _client, Room _room, bool _isCreator)
        {
            InitializeComponent();

            ui = SynchronizationContext.Current;

            window = new WindowController(this);
            mouse = new MouseController();

            client = _client;

            isCreator = _isCreator;

            Update(_room);

            buttonStart.Visible = isCreator;

            var receivingThread = new Thread(ReceiveUpdates);
            receivingThread.IsBackground = true;
            receivingThread.Start();
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                acceptUpdates = false;

                client.Send(new ClientPacket(ClientPacketType.StartGame, client.Nickname, room.Id.ToString()));
            }
            catch { CustomizedMessageBox.Show("Failed to establish connection with the server"); }
            
        }

        private void PlayersWaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientPacketType packetType;

            if (isCreator)
                packetType = ClientPacketType.DeleteRoom;
            else
                packetType = ClientPacketType.LeaveRoom;

            client.Send(new ClientPacket(packetType, client.Nickname, room.Id.ToString()));

            Thread.Sleep(20);

            if (client.IsConnected)
                client.Disconnect();

            acceptUpdates = false;

            Application.Exit();
        }

        private void ReceiveUpdates()
        {
            while (acceptUpdates)
            {
                var packet = client.Receive();

                if (packet == null)
                    return;

                if (packet.Type == ServerPacketType.RoomUpdated)
                {
                    Update(packet.Parameter as Room);
                }
                else if (packet.Type == ServerPacketType.RoomDeleted)
                {
                    room = null;

                    if (!isCreator)
                        CustomizedMessageBox.Show("Creator has left the room. Room deleted");

                    acceptUpdates = false;

                    FormClosing -= PlayersWaitingForm_FormClosing;
                    ui.Send((object state) =>
                    {
                        Close();
                    }, null);
                }
                else if (packet.Type == ServerPacketType.ClientKicked)
                {
                    CustomizedMessageBox.Show("You have been kicked :/");

                    acceptUpdates = false;

                    FormClosing -= PlayersWaitingForm_FormClosing;
                    ui.Send((object state) =>
                    {
                        Close();
                    }, null);
                }
                else if (packet.Type == ServerPacketType.GameStarted)
                {
                    acceptUpdates = false;

                    ui.Send((object state) => 
                    {
                        Hide();
                        new OnlineGameForm(client, room.Id.ToString()).ShowDialog();

                        if (!Disposing && !IsDisposed)
                        {
                            FormClosing -= PlayersWaitingForm_FormClosing;
                            Close();
                        }
                    }, null);
                }
            }
        }

        private void Update(Room _room)
        {
            if (_room == null)
            {
                room = null;
                return;
            }

            ui.Send((object state) =>
            {
                room = _room;
                labelRoomName.Text = room.Name;
                labelPlayersCounter.Text = $"{room.Players.Count}/{room.MaxPlayers}";

                buttonStart.Enabled = room.Players.Count > 1;

                panelPlayers.Controls.Clear();

                foreach (var player in room.Players)
                    panelPlayers.Controls.Add(new PlayerPresenter(player, player == client.Nickname, player == room.CreatorName, isCreator, buttonKick_Click).Present());
            }, null);
        }

        private void buttonKick_Click(object sender, EventArgs e)
        {
            String kickedPlayer = (sender as Control).Tag.ToString();

            client.Send(new ClientPacket(ClientPacketType.KickPlayer, client.Nickname, kickedPlayer, room.Id));

            room.DeletePlayer(kickedPlayer);

            Update(room);
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientPacketType packetType;

            if (isCreator)
                packetType = ClientPacketType.DeleteRoom;
            else
                packetType = ClientPacketType.LeaveRoom;

            client.Send(new ClientPacket(packetType, client.Nickname, room.Id.ToString()));

            room = null;
            acceptUpdates = false;

            FormClosing -= PlayersWaitingForm_FormClosing;
            Close();
        }
    }
}

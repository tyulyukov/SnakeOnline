using SnakeLibrary;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class OnlineGameForm : Form
    {
        private readonly Bitmap gameField;
        private readonly Graphics gameGraphics;

        private OnlineGameInfo gameInfo = null;

        private Client client;

        private WindowController window;
        private MouseController mouse;
        private SynchronizationContext ui;

        private bool acceptUpdates = true;

        private String playingRoomId;

        private DateTime lastPacketSent;
        private DateTime lastPacketHandled;

        private int countLabelShown = 0;

        public OnlineGameForm(Client _client, String _playingRoomId)
        {
            InitializeComponent();

            ui = SynchronizationContext.Current;

            client = _client;

            playingRoomId = _playingRoomId;

            window = new WindowController(this);
            mouse = new MouseController();

            gameField = new Bitmap(panelGame.Width, panelGame.Height);
            gameGraphics = Graphics.FromImage(gameField);
            gameGraphics.PageUnit = GraphicsUnit.Pixel;

            panelWin.BringToFront();
            panelWin.Visible = false;
            panelWin.Location = new Point(Width / 2 - panelWin.Width / 2, Height / 2 - panelWin.Height / 2);

            panelDefeat.BringToFront();
            panelDefeat.Visible = false;
            panelDefeat.Location = new Point(Width / 2 - panelDefeat.Width / 2, Height / 2 - panelDefeat.Height / 2);

            var receivingThread = new Thread(ReceiveUpdates);
            receivingThread.IsBackground = true;
            receivingThread.Start();

            labelYourYdav.Visible = false;
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

        private void ReceiveUpdates()
        {
            countLabelShown = 0;

            while (acceptUpdates)
            {
                ServerPacket packet = null;
                try { packet = client.Receive(); }
                catch (Exception ex) { CustomizedMessageBox.Show(ex.Message); }

                if (packet == null)
                    return;

                if (packet.Type == ServerPacketType.GameUpdated)
                {
                    gameInfo = packet.Parameter as OnlineGameInfo;
                    ui.Send((object state) => 
                    {
                        lastPacketHandled = gameInfo.HandleDate;

                        labelYourYdav.Visible = countLabelShown < 5;

                        if (countLabelShown < 5)
                        {
                            labelYourYdav.Location = new Point(gameInfo.YourSnakeHeadLocation.X - labelYourYdav.Width - 5, gameInfo.YourSnakeHeadLocation.Y);
                            countLabelShown++;
                        }

                        if (lastPacketHandled != DateTime.MinValue)
                            labelPing.Text = "latency: " + (int)(lastPacketHandled - lastPacketSent).TotalMilliseconds + " ms";

                        labelScore.Text = "Score: " + gameInfo.Score; 
                        panelGame.Invalidate(); 
                    }, null);
                }
                else if (packet.Type == ServerPacketType.GameWon)
                {
                    ui.Send((object state) => { panelWin.Visible = true; }, null);

                    KeyDown -= OnlineGameForm_KeyDown;

                    gameInfo = null;
                    acceptUpdates = false;
                }
                else if (packet.Type == ServerPacketType.GameDefeat)
                {
                    ui.Send((object state) => { panelDefeat.Visible = true; }, null);
                    
                    KeyDown -= OnlineGameForm_KeyDown;

                    gameInfo = null;
                    acceptUpdates = false;
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            acceptUpdates = false;
            FormClosing -= OnlineGameForm_FormClosing;
            Close();
        }

        private void OnlineGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            acceptUpdates = false;

            if (client.IsConnected)
                client.Disconnect();

            Application.Exit();
        }

        private void OnlineGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                direction = Direction.Up;
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                direction = Direction.Down;
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                direction = Direction.Left;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                direction = Direction.Right;
            else return;

            lastPacketSent = DateTime.Now;
            client.Send(new ClientPacket(ClientPacketType.ChangeSnakeDirection, client.Nickname, playingRoomId, direction));
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            if (gameInfo != null)
            {
                gameGraphics.Clear(panelGame.BackColor);
                gameInfo.Draw(gameGraphics);
                e.Graphics.DrawImage(gameField, 0, 0);
            }
        }
    }
}

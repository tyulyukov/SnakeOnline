using SnakeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class GameForm : Form
    {
        private readonly Bitmap gameField;
        private readonly Graphics gameGraphics;

        private WindowController window;
        private MouseController mouse;
        private Game game;
        private Queue<Direction> DirectionChanges;

        public GameForm()
        {
            InitializeComponent();

            window = new WindowController(this);
            mouse = new MouseController();

            game = new Game(panelGame.Width, panelGame.Height);
            game.OnGameLost += GameLost;
            game.OnFoodEaten += IncreaseScore;

            gameField = new Bitmap(panelGame.Width, panelGame.Height);
            gameGraphics = Graphics.FromImage(gameField);
            gameGraphics.PageUnit = GraphicsUnit.Pixel;

            DirectionChanges = new Queue<Direction>();

            panelPause.BringToFront();
            panelPause.Visible = false;
            panelPause.Location = new Point(Width / 2 - panelPause.Width / 2, Height / 2 - panelPause.Height / 2);

            panelDefeat.BringToFront();
            panelDefeat.Visible = false;
            panelDefeat.Location = new Point(Width / 2 - panelDefeat.Width / 2, Height / 2 - panelDefeat.Height / 2);

            timerGame.Start();
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

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void buttonPause_MouseEnter(object sender, EventArgs e) => buttonPause.BackColor = Color.FromArgb(74, 85, 100);

        private void buttonPause_MouseLeave(object sender, EventArgs e) => buttonPause.BackColor = this.BackColor;

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            gameGraphics.Clear(panelGame.BackColor);
            game.Draw(gameGraphics);
            e.Graphics.DrawImage(gameField, 0, 0);
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            if (DirectionChanges.Count != 0)
                game.ChangeSnakeDirection(DirectionChanges.Dequeue());
            
            game.MoveSnake();
            panelGame.Invalidate();
        }

        private void GameLost()
        {
            KeyDown -= GameForm_KeyDown;
            timerGame.Stop();
            buttonPause.Enabled = false;
            panelPause.Visible = false;
            panelDefeat.Visible = true;
        }

        private void IncreaseScore() => labelScore.Text = "Score: " + game.Score;

        public void RestartGame()
        {
            DirectionChanges.Clear();
            buttonPause.Enabled = true;
            panelDefeat.Visible = false;
            panelPause.Visible = false;
            labelScore.Text = "Score: 0";
            game.Restart();
            timerGame.Start();
            Focus();
            KeyDown += GameForm_KeyDown;
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                DirectionChanges.Enqueue(Direction.Up);
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                DirectionChanges.Enqueue(Direction.Down);
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                DirectionChanges.Enqueue(Direction.Left);
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                DirectionChanges.Enqueue(Direction.Right);
            else if (e.KeyCode == Keys.Escape)
                Pause();
        }

        private void buttonPause_Click(object sender, EventArgs e) => Pause();
        
        private void buttonRetry_Click(object sender, EventArgs e) => RestartGame();

        private void Pause()
        {
            KeyDown -= GameForm_KeyDown;
            panelPause.Visible = !panelPause.Visible;
            timerGame.Enabled = !timerGame.Enabled;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            panelPause.Visible = false;
            timerGame.Enabled = true;
            Focus();
            KeyDown += GameForm_KeyDown;
        }


        private void buttonLeave_Click(object sender, EventArgs e)
        {
            FormClosing -= GameForm_FormClosing;
            Close();
        }
    }
}

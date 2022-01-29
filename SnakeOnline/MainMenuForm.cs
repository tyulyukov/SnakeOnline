using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class MainMenuForm : Form
    {
        public const int Undefined = -1;

        private WindowController window;
        private MouseController mouse;

        private List<Label> mainMenuButtons;
        private int activeButtonIndex = Undefined;

        public MainMenuForm()
        {
            InitializeComponent();

            window = new WindowController(this);
            mouse = new MouseController();

            mainMenuButtons = new List<Label>() { labelMultiPlayer, labelSinglePlayer, labelExit };
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

        #region Main Menu Buttons

        private void MainMenuButton_MouseEnter(object sender, EventArgs e)
        {
            if (activeButtonIndex != Undefined)
                UnFocusButton(mainMenuButtons[activeButtonIndex]);

            activeButtonIndex = mainMenuButtons.IndexOf(sender as Label);
            FocusButton(sender as Label);
        }
        
        private void MainMenuButton_MouseLeave(object sender, EventArgs e)
        {
            UnFocusButton(sender as Label);
        }

        private void FocusButton(Label label)
        {
            label.BackColor = Color.FromArgb(165, 193, 230);
            label.ForeColor = Color.Black;
        }

        private void UnFocusButton(Label label)
        {
            label.BackColor = panelMenu.BackColor;
            label.ForeColor = Color.White;
        }

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (activeButtonIndex == Undefined)
                {
                    activeButtonIndex = 0;
                }
                else
                {
                    UnFocusButton(mainMenuButtons[activeButtonIndex]);

                    if (activeButtonIndex >= mainMenuButtons.Count - 1)
                        activeButtonIndex = 0;
                    else
                        activeButtonIndex += 1;
                }

                FocusButton(mainMenuButtons[activeButtonIndex]);
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (activeButtonIndex == Undefined)
                {
                    activeButtonIndex = 0;
                }
                else
                {
                    UnFocusButton(mainMenuButtons[activeButtonIndex]);

                    if (activeButtonIndex <= 0)
                        activeButtonIndex = mainMenuButtons.Count - 1;
                    else
                        activeButtonIndex -= 1;
                }

                FocusButton(mainMenuButtons[activeButtonIndex]);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (activeButtonIndex == mainMenuButtons.IndexOf(labelExit))
                {
                    labelExit_Click(null, null);
                }
                else if (activeButtonIndex == mainMenuButtons.IndexOf(labelSinglePlayer))
                {
                    labelSinglePlayer_Click(null, null);
                }
                else if (activeButtonIndex == mainMenuButtons.IndexOf(labelMultiPlayer))
                {
                    labelMultiPlayer_Click(null, null);
                }
            }
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

        private void labelSinglePlayer_Click(object sender, EventArgs e)
        {
            Hide();
            new GameForm().ShowDialog();
            Show();
        }

        private void labelMultiPlayer_Click(object sender, EventArgs e)
        {
            var enterNicknameForm = new EnterNicknameForm();
            if (enterNicknameForm.ShowDialog() == DialogResult.OK)
            {
                Hide();
                var roomsForm = new RoomsForm(enterNicknameForm.Nickname);
                roomsForm.ShowDialog();

                if (!Disposing && !IsDisposed)
                    Show();
            }
        }
    }
}

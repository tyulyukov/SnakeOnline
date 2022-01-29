using System;
using System.Drawing;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class RoomCreatingForm : Form
    {
        public String RoomName { get; private set; }
        public int Count { get; private set; }

        private WindowController window;
        private MouseController mouse;

        public RoomCreatingForm()
        {
            InitializeComponent();

            window = new WindowController(this);
            mouse = new MouseController();

            DialogResult = DialogResult.Cancel;
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

        private void buttonCloseApp_MouseEnter(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Red;

        private void buttonCloseApp_MouseLeave(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Empty;

        #endregion

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                CustomizedMessageBox.Show("Incorrect room name");
                return;
            }

            RoomName = textBoxName.Text.Trim();
            Count = (int)numericUpDownCount.Value;

            DialogResult = DialogResult.OK;
            window.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => window.Close();
    }
}

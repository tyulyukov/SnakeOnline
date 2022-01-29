using System;
using System.Drawing;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class CustomizedMessageBoxForm : Form
    {
        private MouseController mouse;

        public CustomizedMessageBoxForm(String message)
        {
            InitializeComponent();

            mouse = new MouseController();

            DialogResult = DialogResult.Cancel;

            labelMessage.Text = message;

            Name = "Message Box";
        }

        public CustomizedMessageBoxForm(String message, String name) : this(message)
        {
            labelName.Text = name;
            Name = name;
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

        private void buttonCloseApp_MouseEnter(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Red;

        private void buttonCloseApp_MouseLeave(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Empty;

        #endregion

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCloseApp_Click(object sender, EventArgs e) => Close();

        private void buttonCancel_Click(object sender, EventArgs e) => Close();
    }

    public static class CustomizedMessageBox
    {
        public static DialogResult Show(String message) => new CustomizedMessageBoxForm(message).ShowDialog();

        public static DialogResult Show(String message, String name) => new CustomizedMessageBoxForm(message, name).ShowDialog();
    }
}

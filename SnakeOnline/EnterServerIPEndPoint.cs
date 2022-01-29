using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WindowControllers;

namespace SnakeOnline
{
    public partial class EnterServerIPEndPoint : Form
    {
        public IPAddress Ip { get; private set; }
        public int Port { get; private set; }

        private MouseController mouse;

        public EnterServerIPEndPoint()
        {
            InitializeComponent();

            textBoxIp.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

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

        private void buttonCloseApp_Click(object sender, EventArgs e) => Close();

        private void buttonCloseApp_MouseEnter(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Red;

        private void buttonCloseApp_MouseLeave(object sender, EventArgs e) => buttonCloseApp.BackColor = Color.Empty;


        #endregion

        private void buttonOk_Click(object sender, EventArgs e)
        {
            IPAddress result;
            if (!IPAddress.TryParse(textBoxIp.Text, out result))
            {
                CustomizedMessageBox.Show("Incorrect ip");
                return;
            }

            Ip = result;
            Port = (int)numericUpDownPort.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

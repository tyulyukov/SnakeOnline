using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SnakeServer
{
    public partial class MainForm : Form
    {
        private readonly TimeSpan OneSecond = new TimeSpan(0, 0, 0, 1, 0);

        private Server server;
        private SynchronizationContext uiSync;

        private TimeSpan workTime = new TimeSpan(0, 0, 0, 0, 0);

        public MainForm()
        {
            InitializeComponent();

            uiSync = SynchronizationContext.Current;

            textBoxIp.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();

            timerServerWork.Tick += TimerServerWork_Tick;
        }

        private void TimerServerWork_Tick(object sender, EventArgs e)
        {
            workTime = workTime.Add(OneSecond);
            labelWorkTime.Text = workTime.ToString();
        }

        private void OnLogReceived(String log) 
        { 
            if (!IsDisposed && !Disposing) 
                uiSync.Send(ShowMessage, log);
        }

        private void ShowMessage(object state) => listBoxLogs.Items.Add($"{DateTime.Now.ToShortTimeString()} | " + state);

        private void OnGameLogReceived(String log)
        {
            if (!IsDisposed && !Disposing)
                uiSync.Send(ShowGameMessage, log);
        }

        private void ShowGameMessage(object state) => listBoxGameLogs.Items.Add($"{DateTime.Now.ToShortTimeString()} | " + state);

        private void buttonStart_Click(object sender, EventArgs e)
        {
            textBoxIp.Enabled = false;
            numericUpDownPort.Enabled = false;

            server = new Server(textBoxIp.Text, (int)numericUpDownPort.Value);
            server.OnLogReceived += OnLogReceived;
            server.OnGameLogReceived += OnGameLogReceived;

            buttonStart.Enabled = false;

            var thread = new Thread(() =>
            {
                server.Start();
                uiSync.Send((object state) => buttonStart.Enabled = (bool)state, true);
                timerServerWork.Stop();
                textBoxIp.Enabled = true;
                numericUpDownPort.Enabled = true;
            });
            thread.IsBackground = true;
            thread.Start();
            timerServerWork.Start();
        }
    }
}

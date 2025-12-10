using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;

        public ClientForm() => InitializeComponent();

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 9000);
                stream = client.GetStream();
                listenThread = new Thread(ListenServer);
                listenThread.IsBackground = true;
                listenThread.Start();

                lb_status.Text = " Đã kết nối đến server";
                lb_status.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lb_status.Text = " Không kết nối được server: " + ex.Message;
                lb_status.ForeColor = Color.Red;
            }
        }

        private void ListenServer()
        {
            byte[] buffer = new byte[2048];
            while (true)
            {
                try
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();
                    this.Invoke((Action)(() =>
                    {

                    }));
                }
                catch
                {
                    break;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                stream?.Close();
                client?.Close();
            }
            catch { }
            base.OnFormClosing(e);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();
                listenThread.Start();
                lb_status.Text = " Đã kết nối đến server";
                lb_status.ForeColor = Color.Green;
            }
            catch
            {
                lb_status.Text = " Không kết nối được server";
                lb_status.ForeColor = Color.Red;
            }
        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class ServerForm : Form
    {
        TcpListener listener;
        Thread listenThread;
        List<TcpClient> clients = new List<TcpClient>();
        string dbPath;

        public ServerForm()
        {
            InitializeComponent();
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            listenThread = new Thread(NhanClient);
            listenThread.IsBackground = true;
            listenThread.Start();
            lb_status.Text = "Server đang chạy trên cổng 8888";
        }

        private void NhanClient()
        {
            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    lock (clients)
                    {
                        clients.Add(client);
                    }
                    this.Invoke((Action)(() =>
                    {
                        lv_log.Items.Add($"Client mới kết nối: {client.Client.RemoteEndPoint}");
                    }));

                    Thread t = new Thread(() => XuLyClient(client));
                    t.IsBackground = true;
                    t.Start();
                }
                catch { break; }
            }
        }
        private void XuLyClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[2048];
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                try
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    this.Invoke((Action)(() =>
                    {
                        lv_log.Items.Add($"Nhận: {msg}");
                    }));

                    if (msg.StartsWith("ADD|"))
                    {
                        string[] parts = msg.Split('|');
                        if (parts.Length >= 4)
                        {
                            string ten = parts[1];
                            string mon = parts[2];
                            string hinh = parts[3].Replace("\n", "").Trim();
                            Broadcast(msg);
                        }
                    }
                    else if (msg.StartsWith("GETALL"))
                    {
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((Action)(() =>
                    {
                        lv_log.Items.Add($"Lỗi: {ex.Message}");
                    }));
                    break;
                }
            }

            lock (clients)
            {
                clients.Remove(client);
                this.Invoke((Action)(() =>
                {
                    lv_log.Items.Add($"Client ngắt kết nối");
                }));
            }
            client.Close();
        }

        private void Broadcast(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            lock (clients)
            {
                foreach (var c in clients.ToList())
                {
                    try
                    {
                        c.GetStream().Write(data, 0, data.Length);
                    }
                    catch
                    {
                        clients.Remove(c);
                    }
                }
            }
        }

        private void btn_charge_Click(object sender, EventArgs e)
        {

        }
    }
}

    

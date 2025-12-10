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

        private void ServerForm_Load(object sender, EventArgs e)
        {
            dbPath = Path.Combine(Application.StartupPath, "monan_server.db");

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                TaoCauTrucDB();
            }
            else
            {
                TaoCauTrucDB();
            }
            lv_log.View = View.List;
        }

        private void TaoCauTrucDB()
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS MonAn (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        HoTen TEXT,
                        TenMon TEXT,
                        Hinh TEXT)";
                new SQLiteCommand(sql, conn).ExecuteNonQuery();
                conn.Close();
            }
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

        private void BroadcastAllData()
        {
            string data = "";
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT HoTen, TenMon, Hinh FROM MonAn", conn);
                SQLiteDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    data += $"{r["HoTen"]}|{r["TenMon"]}|{r["Hinh"]}#";
                }
                conn.Close();
            }

            byte[] sendData = Encoding.UTF8.GetBytes("DATA|" + data);
            lock (clients)
            {
                foreach (var c in clients.ToList())
                {
                    try { c.GetStream().Write(sendData, 0, sendData.Length); }
                    catch { clients.Remove(c); }
                }
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

                            ThemMonAn(ten, mon, hinh);
                            Broadcast(msg);
                            BroadcastAllData();
                        }
                    }
                    else if (msg.StartsWith("GETALL"))
                    {
                        GuiTatCaMon(client);
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

        private void ThemMonAn(string ten, string mon, string hinh)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "INSERT INTO MonAn (HoTen, TenMon, Hinh) VALUES (@a,@b,@c)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@a", ten);
                cmd.Parameters.AddWithValue("@b", mon);
                cmd.Parameters.AddWithValue("@c", hinh);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            this.Invoke((Action)(() =>
            {
                lv_log.Items.Add($"{ten} them mon {mon}");
            }));
        }

        private void GuiTatCaMon(TcpClient client)
        {
            string data = "";
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT HoTen, TenMon, Hinh FROM MonAn", conn);
                SQLiteDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    data += $"{r["HoTen"]}|{r["TenMon"]}|{r["Hinh"]}#";
                }
                conn.Close();
            }

            byte[] sendData = Encoding.UTF8.GetBytes("DATA|" + data);
            client.GetStream().Write(sendData, 0, sendData.Length);
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

    }
}

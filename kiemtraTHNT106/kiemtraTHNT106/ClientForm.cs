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
        private string tenNguoi;
        private readonly List<MonAn> dsMonAn = new();

        public ClientForm() => InitializeComponent();

        private void ClientForm_Load(object sender, EventArgs e)
        {
            tenNguoi = "User" + new Random().Next(100, 999);
            lb_ten.Text = $"Tên người dùng: {tenNguoi}";
            lv_monan.View = View.List;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();
                listenThread = new Thread(NhanDL) { IsBackground = true };
                listenThread.Start();

                lb_status.Text = " Đã kết nối đến server";
                lb_status.ForeColor = Color.Green;
                lv_monan.Items.Add("Kết nối thành công đến server!");
            }
            catch
            {
                lb_status.Text = " Không kết nối được server";
                lb_status.ForeColor = Color.Red;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_mon.Text)) return;
            if (stream == null || !client.Connected)
            {
                MessageBox.Show("Chưa kết nối đến server!");
                return;
            }

            string mon = tb_mon.Text.Trim();
            string hinh = tb_hinh.Text.Trim();

            if (!Path.IsPathRooted(hinh))
                hinh = Path.Combine(Application.StartupPath, hinh);

            string msg = $"ADD|{tenNguoi}|{mon}|{hinh}";
            byte[] data = Encoding.UTF8.GetBytes(msg);
            stream.Write(data, 0, data.Length);
            stream.Flush();

            lv_monan.Items.Add($"[Bạn đã thêm]: {mon}");
            tb_mon.Clear();
        }

        private void btn_getAll_Click(object sender, EventArgs e)
        {
            if (stream == null || !client.Connected)
            {
                MessageBox.Show("Chưa kết nối đến server!");
                return;
            }
            byte[] data = Encoding.UTF8.GetBytes("GETALL");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }

        private void NhanDL()
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                try
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    if (msg.StartsWith("ADD|"))
                    {
                        string[] p = msg.Split('|');
                        if (p.Length >= 3)
                        {
                            this.Invoke(() =>
                                lv_monan.Items.Add($"[Server]: {p[1]} đã thêm món {p[2]}")
                            );
                        }
                    }
                    else if (msg.StartsWith("DATA|"))
                    {
                        dsMonAn.Clear();
                        string[] items = msg.Substring(5).Split('#');
                        this.Invoke(() =>
                        {
                            lv_monan.Items.Clear();
                            lv_monan.Items.Add("[Danh sách món ăn]");
                            foreach (string s in items)
                            {
                                if (string.IsNullOrWhiteSpace(s)) continue;
                                var p = s.Split('|');
                                if (p.Length >= 3)
                                {
                                    dsMonAn.Add(new MonAn { TenNguoi = p[0], TenMon = p[1], Hinh = p[2] });
                                    lv_monan.Items.Add($"{p[0]} - {p[1]}");
                                }
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(() =>
                    {
                        lb_status.Text = " Mất kết nối đến server";
                        lb_status.ForeColor = Color.Red;
                        lv_monan.Items.Add($"Lỗi: {ex.Message}");
                    });
                    break;
                }
            }
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            if (dsMonAn.Count == 0)
            {
                MessageBox.Show("Chưa có món nào! Hãy bấm 'Lấy toàn bộ' trước.");
                return;
            }

            Random rnd = new Random();
            var mon = dsMonAn[rnd.Next(dsMonAn.Count)];
            lblTenMon.Text = $"Tên món: {mon.TenMon}";

            try
            {
                if (File.Exists(mon.Hinh))
                    pictureBox1.Image = Image.FromFile(mon.Hinh);
                else
                    pictureBox1.Image = null;
            }
            catch
            {
                pictureBox1.Image = null;
            }

            MessageBox.Show($" Hôm nay ăn: {mon.TenMon} ", "Kết quả");
        }

    }
}

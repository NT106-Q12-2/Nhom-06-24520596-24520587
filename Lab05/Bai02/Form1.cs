
using System;
using System.Windows.Forms;
using MailKit.Net.Imap;
using System.Drawing;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureListView();
        }
        private void ConfigureListView()
        {
            listViewEmails.View = View.Details;
            listViewEmails.FullRowSelect = true;
            listViewEmails.GridLines = true;
            listViewEmails.Font = new Font("Segoe UI", 9F);
            listViewEmails.Columns.Add("Subject", 400);
            listViewEmails.Columns.Add("From", 300);
            listViewEmails.Columns.Add("Date", 200);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập Email!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập Password!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
                string input = InputDialog.Show(
                    "Số lượng email",
                    "Nhập số lượng email muốn tải:",
                    "10");

                if (string.IsNullOrWhiteSpace(input))
                {
                    return; 
                }
                if (!int.TryParse(input, out int limit) || limit <= 0)
                {
                    MessageBox.Show("Số lượng email phải là số nguyên dương!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnLogin.Enabled = false;
                lblStatus.Text = "Đang kết nối...";
                lblStatus.ForeColor = Color.Blue;
                Application.DoEvents(); 
                listViewEmails.Items.Clear();
                lblTotal.Text = "Total: 0";
                lblRecent.Text = "Recent: 0";

              
                var client = new ImapClient();
                string server = "imap.gmail.com";
                int port = 993;

                client.Connect(server, port, true); 
                client.Authenticate(txtEmail.Text.Trim(), txtPassword.Text); 

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);
                int totalEmails = inbox.Count;
                int emailsToLoad = Math.Min(limit, totalEmails);


                lblTotal.Text = "Total: " + totalEmails.ToString();
                lblRecent.Text = "Recent: " + emailsToLoad.ToString();
                for (int i = totalEmails - 1; i >= totalEmails - emailsToLoad; i--)
                {
                    var message = inbox.GetMessage(i);
                    ListViewItem item = new ListViewItem(message.Subject ?? "(No Subject)");
                    string fromAddress = "";
                    if (message.From != null && message.From.Count > 0)
                    {
                        fromAddress = message.From.ToString();
                    }
                    item.SubItems.Add(fromAddress);
                    string dateStr = message.Date.ToString("dd/MM/yyyy HH:mm:ss");
                    item.SubItems.Add(dateStr);
                    listViewEmails.Items.Add(item);
                }

                client.Disconnect(true);
                lblStatus.Text = "Kết nối thành công!";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show($"Đã tải {emailsToLoad} email thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Kết nối thất bại!";
                lblStatus.ForeColor = Color.Red;

                string errorMessage = $"Lỗi: {ex.Message}\n\nLưu ý: Nếu dùng Gmail, bạn cần:\n";

                MessageBox.Show(errorMessage, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
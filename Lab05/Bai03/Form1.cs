
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private string selectedProtocol = "IMAP"; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureListView();
            UpdateProtocolSelection();
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
        private void UpdateProtocolSelection()
        {
            if (radioIMAP.Checked)
            {
                selectedProtocol = "IMAP";
                lblSelected.Text = "Đã chọn: IMAP\n";
                lblSelected.ForeColor = Color.FromArgb(59, 130, 246); 
            }
            else if (radioPOP3.Checked)
            {
                selectedProtocol = "POP3";
                lblSelected.Text = "Đã chọn: POP3\n";
                lblSelected.ForeColor = Color.FromArgb(16, 185, 129); 
            }

            lblStatus.Text = $"Bài 3 - Phương thức: {selectedProtocol}";
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
                UpdateProtocolSelection();
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
                radioIMAP.Enabled = false;
                radioPOP3.Enabled = false;
                lblStatus.Text = $"Bài 3: Đang kết nối {selectedProtocol}...";
                lblStatus.ForeColor = Color.Blue;
                Application.DoEvents();

                listViewEmails.Items.Clear();
                lblTotal.Text = "Total: 0";
                lblRecent.Text = "Recent: 0";

                int emailsToLoad = 0;
                if (selectedProtocol == "IMAP")
                {
                    emailsToLoad = ConnectIMAP(limit);
                }
                else 
                {
                    emailsToLoad = ConnectPOP3(limit);
                }

                lblStatus.Text = $"Bài 3: Kết nối {selectedProtocol} thành công!";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show($"Bài 3: Đã tải {emailsToLoad} email thành công bằng {selectedProtocol}!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Bài 3: Kết nối {selectedProtocol} thất bại!";
                lblStatus.ForeColor = Color.Red;

                string errorMessage = $"Bài 3 - Lỗi {selectedProtocol}: {ex.Message}\n";
                MessageBox.Show(errorMessage, $"Bài 3 - Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                radioIMAP.Enabled = true;
                radioPOP3.Enabled = true;
            }
        }
        private int ConnectIMAP(int limit)
        {
            using (var client = new ImapClient())
            {
                string server = "imap.gmail.com";
                int port = 993;

                client.Connect(server, port, true);
                client.Authenticate(txtEmail.Text.Trim(), txtPassword.Text);

                var inbox = client.Inbox;
                inbox.Open(MailKit.FolderAccess.ReadOnly);

                int totalEmails = inbox.Count;
                int emailsToLoad = Math.Min(limit, totalEmails);

                lblTotal.Text = $"Total: {totalEmails}";
                lblRecent.Text = $"Recent: {emailsToLoad}";

                for (int i = totalEmails - 1; i >= totalEmails - emailsToLoad && i >= 0; i--)
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
                    item.SubItems.Add("IMAP");

                    listViewEmails.Items.Add(item);
                }

                client.Disconnect(true);
                return emailsToLoad;
            }
        }

        private int ConnectPOP3(int limit)
        {
            using (var client = new Pop3Client())
            {
                string server = "pop.gmail.com";
                int port = 995;

                client.Connect(server, port, true);
                client.Authenticate(txtEmail.Text.Trim(), txtPassword.Text);

                int totalEmails = client.Count;
                int emailsToLoad = Math.Min(limit, totalEmails);

                lblTotal.Text = $"Total: {totalEmails}";
                lblRecent.Text = $"Recent: {emailsToLoad}";

                for (int i = 0; i < emailsToLoad; i++)
                {
                    var message = client.GetMessage(i);
                    ListViewItem item = new ListViewItem(message.Subject ?? "(No Subject)");

                    string fromAddress = "";
                    if (message.From != null && message.From.Count > 0)
                    {
                        fromAddress = message.From.ToString();
                    }
                    item.SubItems.Add(fromAddress);

                    string dateStr = message.Date.ToString("dd/MM/yyyy HH:mm:ss");
                    item.SubItems.Add(dateStr);
                    item.SubItems.Add("POP3");

                    listViewEmails.Items.Add(item);
                }

                client.Disconnect(true);
                return emailsToLoad;
            }
        }

    }
}
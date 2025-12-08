using Bai06;
using MailKit;
using MailKit.Net.Imap;
using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace EmailClientApp
{
    public partial class Form1 : Form
    {
        private ImapClient imapClient;
        private string currentEmail;
        private string currentPassword;
        private readonly object imapLock = new object();

        public Form1()
        {
            InitializeComponent();
            InitializeDefaultValues();
        }

        private void InitializeDefaultValues()
        {
            cb_IMAP.Items.AddRange(new string[] { "imap.gmail.com", "outlook.office365.com" });
            cb_SMTP.Items.AddRange(new string[] { "smtp.gmail.com", "smtp.office365.com" });

            cb_IMAP.SelectedIndex = 0;
            cb_SMTP.SelectedIndex = 0;
            tb_IMAPPort.Text = "993";
            tb_SMTPPort.Text = "465";

            btn_GuiMail.Enabled = false;
            btn_Refresh.Enabled = false;
            btn_DangXuat.Enabled = false;

            tb_TaiKhoan.Text = "legendhung862@gmail.com";
            tb_MatKhau.Text = "infa kmlw ckxn vdta";
        }

        private async void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_TaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(tb_MatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btn_DangNhap.Enabled = false;
                btn_DangNhap.Text = "Đang đăng nhập...";
                Application.DoEvents();

                currentEmail = tb_TaiKhoan.Text.Trim();
                currentPassword = tb_MatKhau.Text;

                if (imapClient != null)
                {
                    if (imapClient.IsConnected)
                        await imapClient.DisconnectAsync(true);
                    imapClient.Dispose();
                }

                imapClient = new ImapClient();
                await imapClient.ConnectAsync(cb_IMAP.Text, int.Parse(tb_IMAPPort.Text), true);
                await imapClient.AuthenticateAsync(currentEmail, currentPassword);

                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_GuiMail.Enabled = true;
                btn_Refresh.Enabled = true;
                btn_DangXuat.Enabled = true;
                btn_DangNhap.Enabled = false;
                tb_TaiKhoan.Enabled = false;
                tb_MatKhau.Enabled = false;

                LoadEmails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_DangNhap.Enabled = true;
                btn_DangNhap.Text = "Đăng nhập";
            }
        }

        private async void LoadEmails()
        {
            try
            {
                dgv_EmailList.Rows.Clear();

                lock (imapLock)
                {
                    if (imapClient == null || !imapClient.IsConnected)
                    {
                        MessageBox.Show("Chưa kết nối IMAP!", "Lỗi");
                        return;
                    }
                }

                var inbox = imapClient.Inbox;
                if (!inbox.IsOpen)
                    await inbox.OpenAsync(FolderAccess.ReadOnly);

                int totalEmails = inbox.Count;

                if (totalEmails == 0) return;

                int emailsToLoad = Math.Min(50, totalEmails);
                int startIndex = totalEmails - emailsToLoad;
                int endIndex = totalEmails - 1;
                var summaries = await inbox.FetchAsync(startIndex, endIndex,
                    MessageSummaryItems.Envelope | MessageSummaryItems.InternalDate);
                foreach (var item in summaries.Reverse())
                {
                    string from = item.Envelope.From.FirstOrDefault()?.ToString() ?? "(No sender)";
                    string subject = item.Envelope.Subject ?? "(No subject)";

                    string datetime = item.InternalDate.HasValue
                        ? item.InternalDate.Value.ToString("dd/MM/yyyy HH:mm")
                        : "(No date)";

                    dgv_EmailList.Rows.Add(item.Index + 1, from, subject, datetime);
                }

                MessageBox.Show($"Đã tải {summaries.Count} email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải email: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadEmails();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            try
            {
                lock (imapLock)
                {
                    if (imapClient != null && imapClient.IsConnected)
                    {
                        imapClient.Disconnect(true);
                        imapClient.Dispose();
                        imapClient = null;
                    }
                }

                btn_GuiMail.Enabled = false;
                btn_Refresh.Enabled = false;
                btn_DangXuat.Enabled = false;
                btn_DangNhap.Enabled = true;
                tb_TaiKhoan.Enabled = true;
                tb_MatKhau.Enabled = true;
                tb_MatKhau.Clear();

                dgv_EmailList.Rows.Clear();

                MessageBox.Show("Đã đăng xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng xuất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GuiMail_Click(object sender, EventArgs e)
        {
            FormSendMail formSend = new FormSendMail(currentEmail, currentPassword,
                cb_SMTP.Text, int.Parse(tb_SMTPPort.Text));
            formSend.ShowDialog();
        }

        private async void dgv_EmailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                int emailIndex = int.Parse(dgv_EmailList.Rows[e.RowIndex].Cells[0].Value.ToString()) - 1;

                lock (imapLock)
                {
                    if (imapClient == null || !imapClient.IsConnected)
                    {
                        MessageBox.Show("Chưa kết nối IMAP!", "Lỗi");
                        return;
                    }
                }

                var inbox = imapClient.Inbox;
                if (!inbox.IsOpen)
                    await inbox.OpenAsync(FolderAccess.ReadOnly);

                var message = await inbox.GetMessageAsync(emailIndex);

                FormReadMail formRead = new FormReadMail(message, currentEmail, currentPassword,
                    cb_SMTP.Text, int.Parse(tb_SMTPPort.Text));
                formRead.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở email: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lock (imapLock)
                {
                    if (imapClient != null && imapClient.IsConnected)
                    {
                        imapClient.Disconnect(true);
                        imapClient.Dispose();
                    }
                }
            }
            catch { }
        }
    }
}
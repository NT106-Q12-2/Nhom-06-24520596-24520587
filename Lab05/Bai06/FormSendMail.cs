using System;
using System.IO;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailClientApp
{
    public partial class FormSendMail : Form
    {
        private string senderEmail;
        private string senderPassword;
        private string smtpServer;
        private int smtpPort;
        private string attachmentPath = "";

        public FormSendMail(string email, string password, string smtp, int port)
        {
            InitializeComponent();
            senderEmail = email;
            senderPassword = password;
            smtpServer = smtp;
            smtpPort = port;
            tb_From.Text = email;
        }

        public FormSendMail(string email, string password, string smtp, int port,
            string replyTo, string replySubject, string replyBody)
        {
            InitializeComponent();
            senderEmail = email;
            senderPassword = password;
            smtpServer = smtp;
            smtpPort = port;
            tb_From.Text = email;
            tb_To.Text = replyTo;
            tb_Subject.Text = replySubject;
            rtb_Body.Text = replyBody;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn file đính kèm";
                openFileDialog.Filter = "Tất cả files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentPath = openFileDialog.FileName;
                    tb_Attachment.Text = Path.GetFileName(attachmentPath);
                }
            }
        }

        private async void btn_SendMail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_To.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ người nhận!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_Subject.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btn_SendMail.Enabled = false;
                btn_SendMail.Text = "Đang gửi...";
                Application.DoEvents();

                var message = new MimeMessage();

                string displayName = string.IsNullOrWhiteSpace(tb_Name.Text) ? "" : tb_Name.Text.Trim();
                message.From.Add(new MailboxAddress(displayName, tb_From.Text.Trim()));
                message.To.Add(new MailboxAddress("", tb_To.Text.Trim()));
                message.Subject = tb_Subject.Text.Trim();

                var builder = new BodyBuilder();

                if (cb_HTML.Checked)
                {
                    builder.HtmlBody = rtb_Body.Text;
                }
                else
                {
                    builder.TextBody = rtb_Body.Text;
                }

                if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
                {
                    builder.Attachments.Add(attachmentPath);
                }

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, true);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show("Email đã được gửi thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi email: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_SendMail.Enabled = true;
                btn_SendMail.Text = "Gửi mail";
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ClearAttachment_Click(object sender, EventArgs e)
        {
            attachmentPath = "";
            tb_Attachment.Clear();
        }
    }
}
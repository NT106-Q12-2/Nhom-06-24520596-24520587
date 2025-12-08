using System;
using System.Linq;
using System.Windows.Forms;
using MimeKit;

namespace EmailClientApp
{
    public partial class FormReadMail : Form
    {
        private MimeMessage currentMessage;
        private string senderEmail;
        private string senderPassword;
        private string smtpServer;
        private int smtpPort;

        public FormReadMail(MimeMessage message, string email, string password, string smtp, int port)
        {
            InitializeComponent();
            currentMessage = message;
            senderEmail = email;
            senderPassword = password;
            smtpServer = smtp;
            smtpPort = port;
            LoadEmailContent();
        }

        private void LoadEmailContent()
        {
            try
            {
                tb_From.Text = currentMessage.From.FirstOrDefault()?.ToString() ?? "(No sender)";
                tb_To.Text = currentMessage.To.FirstOrDefault()?.ToString() ?? "(No recipient)";
                tb_Subject.Text = currentMessage.Subject ?? "(No subject)";

                string bodyContent = "";

                if (!string.IsNullOrEmpty(currentMessage.HtmlBody))
                {
                    bodyContent = currentMessage.HtmlBody;
                }
                else if (!string.IsNullOrEmpty(currentMessage.TextBody))
                {
                    bodyContent = "<html><body><pre>" +
                        System.Net.HttpUtility.HtmlEncode(currentMessage.TextBody) +
                        "</pre></body></html>";
                }
                else
                {
                    bodyContent = "<html><body><p>(Email không có nội dung)</p></body></html>";
                }

                wb_Body.DocumentText = bodyContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị email: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reply_Click(object sender, EventArgs e)
        {
            try
            {
                string replyTo = currentMessage.From.FirstOrDefault()?.ToString() ?? "";
                string replySubject = currentMessage.Subject ?? "";

                if (!replySubject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
                {
                    replySubject = "Re: " + replySubject;
                }

                string replyBody = "\r\n\r\n--- Email gốc ---\r\n";
                replyBody += $"From: {tb_From.Text}\r\n";
                replyBody += $"Date: {currentMessage.Date}\r\n";
                replyBody += $"Subject: {tb_Subject.Text}\r\n\r\n";

                if (!string.IsNullOrEmpty(currentMessage.TextBody))
                {
                    replyBody += currentMessage.TextBody;
                }

                FormSendMail formSend = new FormSendMail(senderEmail, senderPassword,
                    smtpServer, smtpPort, replyTo, replySubject, replyBody);
                formSend.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form reply: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
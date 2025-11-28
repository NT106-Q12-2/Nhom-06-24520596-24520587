using System;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

namespace Lab05_Bai01
{
    public partial class Form1 : Form
    {
        private const string SMTP_HOST = "smtp.gmail.com";
        private const int SMTP_PORT = 465;
        private const bool USE_SSL = true;

        private const string APP_PASSWORD = "gruq hnor hgcq wnsv";

        public Form1()
        {
            InitializeComponent();
            InitializeDefaultValues();
        }

        private void InitializeDefaultValues()
        {
            lbl_status.Text = "Status: Ready";
            tb_from.Text = "";
            tb_to.Text = "";
            tb_subject.Text = "";
            rtb_body.Text = "Hello,\r\nTest email.\r\nBest regard!";
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                lbl_status.Text = "Status: Sending email...";
                btn_send.Enabled = false;

                await SendEmailSimpleAsync();

                lbl_status.Text = "Status: Email sent successfully!";
                MessageBox.Show("Email sent successfully!", "Success");
            }
            catch (Exception ex)
            {
                lbl_status.Text = "Status: Error occurred";
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                btn_send.Enabled = true;
            }
        }

        private async System.Threading.Tasks.Task SendEmailSimpleAsync()
        {
            var client = new SmtpClient();

            client.Connect(SMTP_HOST, SMTP_PORT, USE_SSL);

            client.Authenticate(tb_from.Text.Trim(), APP_PASSWORD);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", tb_from.Text.Trim()));
            message.To.Add(new MailboxAddress("", tb_to.Text.Trim()));
            message.Subject = tb_subject.Text.Trim();
            message.Body = new TextPart("plain")
            {
                Text = rtb_body.Text.Trim()
            };

            client.Send(message);

            client.Disconnect(true);
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tb_from.Text) ||
                string.IsNullOrWhiteSpace(tb_to.Text) ||
                string.IsNullOrWhiteSpace(tb_subject.Text) ||
                string.IsNullOrWhiteSpace(rtb_body.Text))
            {
                MessageBox.Show("Please fill all fields!", "Validation Error");
                return false;
            }
            return true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_to.Clear();
            tb_subject.Clear();
            rtb_body.Clear();
            lbl_status.Text = "Status: Form cleared";
            tb_to.Focus();
        }
    }
}
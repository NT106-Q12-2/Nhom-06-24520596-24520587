using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace Bai05
{
    public partial class AddFoodForm : Form
    {
        private string selectedImagePath = "";
        private const string ADMIN_EMAIL = "hoangphihung20072006@gmail.com"; 
        public event EventHandler<FoodItem> FoodAdded;

        public AddFoodForm()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tất cả|*.*";
                openFileDialog.Title = "Chọn hình ảnh món ăn";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    txtImageUrl.Text = selectedImagePath; 
                }
            }
        }

        private void btnAddLocal_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedImagePath) || !File.Exists(selectedImagePath))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh từ máy", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtFoodName.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FoodItem newFood = new FoodItem
                {
                    FoodName = txtFoodName.Text.Trim(),
                    ImagePath = selectedImagePath,
                    Contributor = txtContributor.Text.Trim(),
                    ContributorEmail = txtEmail.Text.Trim(),
                    AddedDate = DateTime.Now
                };

                FoodAdded?.Invoke(this, newFood);

                MessageBox.Show($"Đã thêm: {newFood.FoodName}", "Thành công",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string foodName = txtFoodName.Text.Trim();
                string imagePath = selectedImagePath;
                string senderEmail = txtEmail.Text.Trim();
                string senderPassword = txtPassword.Text;
                string contributor = txtContributor.Text.Trim();

                if (string.IsNullOrEmpty(foodName))
                {
                    MessageBox.Show("Vui lòng nhập tên món ăn", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Vui lòng chọn ảnh trước khi gửi email", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(senderEmail))
                {
                    MessageBox.Show("Vui lòng nhập email của bạn", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnSendEmail.Enabled = false;
                btnSendEmail.Text = "Đang gửi...";

                string subject = "Đóng góp món ăn";
                string body = $"{foodName}\nNgười đóng góp: {contributor}";

                await Task.Run(() => SendEmailToAdmin(senderEmail, senderPassword, subject, body));

                MessageBox.Show($"Đã gửi đóng góp thành công", "THÀNH CÔNG",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi email: {ex.Message}", "LỖI",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSendEmail.Enabled = true;
                btnSendEmail.Text = "GỬI EMAIL";
            }
        }
        private void SendEmailToAdmin(string senderEmail, string senderPassword, string subject, string body)
        {
            try
            {
                if (!File.Exists(selectedImagePath))
                {
                    throw new Exception("File ảnh không tồn tại!");
                }

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 15000;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(ADMIN_EMAIL);
                        mail.CC.Add(senderEmail);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = false;
                        mail.Attachments.Add(new Attachment(selectedImagePath));
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể gửi email đến admin: {ex.Message}");
            }
        }

        private void AddFoodForm_Load(object sender, EventArgs e)
        {
            txtFoodName.Select(); 
            label5.Text = $"Hình ảnh (sẽ gửi đến: {ADMIN_EMAIL}):";
        }
    }

    public class FoodItem
    {
        public string FoodName { get; set; }
        public string ImagePath { get; set; }
        public string Contributor { get; set; }
        public string ContributorEmail { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
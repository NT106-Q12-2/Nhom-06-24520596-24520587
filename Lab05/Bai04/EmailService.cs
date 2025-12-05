using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Windows.Forms;

namespace Bai04.EServices
{
    public class EmailService
    {
        private readonly string _smtpHost = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _senderEmail = "legendhung862@gmail.com";
        private readonly string _senderName = "Cinema++";
        private readonly string _appPassword = "dsvdfppqadtqplrp";
        private readonly string _slogan = "Cảm ơn bạn đã lựa chọn chúng tôi! Chúc bạn xem phim vui vẻ!";

        public async Task<bool> SendBookingConfirmationAsync(
            string toEmail,
            string customerName,
            string movieName,
            List<string> seats,
            string posterUrl = "",
            string ticketId = "",
            decimal totalAmount = 0)
        {
            try
            {
                var message = CreateEmailMessage(
                    toEmail,
                    customerName,
                    movieName,
                    seats,
                    posterUrl,
                    ticketId,
                    totalAmount
                );

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_senderEmail, _appPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show(
                    $"✓ Đã gửi email xác nhận đến {toEmail}!",
                    "Gửi email thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return true;
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi gửi email:\n\n" +
                                $"Người nhận: {toEmail}\n" +
                                $"Lỗi: {ex.Message}\n\n" +
                                $"Chi tiết: {ex.InnerException?.Message ?? "Không có"}";

                MessageBox.Show(
                    errorMsg,
                    "Lỗi gửi email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        private MimeMessage CreateEmailMessage(
            string toEmail,
            string customerName,
            string movieName,
            List<string> seats,
            string posterUrl,
            string ticketId,
            decimal totalAmount)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_senderName, _senderEmail));
            message.To.Add(new MailboxAddress(customerName, toEmail));
            message.Subject = $"🎬 Xác nhận đặt vé: {movieName}";

            string seatsStr = string.Join(", ", seats);
            string htmlBody = CreateEmailHtmlBody(
                customerName,
                movieName,
                seatsStr,
                posterUrl,
                ticketId,
                totalAmount,
                toEmail
            );

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlBody
            };

            return message;
        }

        private string CreateEmailHtmlBody(
            string customerName,
            string movieName,
            string seats,
            string posterUrl,
            string ticketId,
            decimal totalAmount,
            string toEmail)
        {
            bool hasPoster = !string.IsNullOrEmpty(posterUrl) &&
                           !posterUrl.Contains("placeholder") &&
                           (posterUrl.StartsWith("http://") || posterUrl.StartsWith("https://"));

            if (hasPoster)
            {
                return CreateEmailWithPosterBackground(
                    customerName, movieName, seats, posterUrl, ticketId, totalAmount, toEmail
                );
            }
            else
            {
                return CreateEmailWithGradientBackground(
                    customerName, movieName, seats, ticketId, totalAmount, toEmail
                );
            }
        }

        private string CreateEmailWithPosterBackground(
            string customerName,
            string movieName,
            string seats,
            string posterUrl,
            string ticketId,
            decimal totalAmount,
            string toEmail)
        {
            return $@"
<!DOCTYPE html>
<html lang='vi'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Xác nhận đặt vé</title>
</head>
<body style='margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background-color: #1a1a1a;'>
    
    <!-- Background Wrapper với Poster -->
    <div style='background-image: url({posterUrl}); background-size: cover; background-position: center; background-repeat: no-repeat; padding: 40px 20px; min-height: 100vh;'>
        
        <!-- Overlay tối để text dễ đọc -->
        <div style='background-color: rgba(0,0,0,0.7); padding: 20px 0;'>
            
            <!-- Center Container -->
            <table width='100%' cellpadding='0' cellspacing='0' border='0'>
                <tr>
                    <td align='center'>
                        
                        <!-- Main Content Card -->
                        <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: rgba(255,255,255,0.98); border-radius: 15px; overflow: hidden; box-shadow: 0 10px 40px rgba(0,0,0,0.8); max-width: 600px;'>
                            
                            <!-- Header -->
                            <tr>
                                <td style='background: linear-gradient(135deg, rgba(102,126,234,0.95) 0%, rgba(118,75,162,0.95) 100%); padding: 40px 30px; text-align: center;'>
                                    <h1 style='color: #ffffff; margin: 0; font-size: 36px; text-shadow: 3px 3px 6px rgba(0,0,0,0.6);'>
                                        🎬 Cinema++
                                    </h1>
                                    <p style='color: #ffd700; margin: 15px 0 0 0; font-size: 20px; font-weight: bold; text-shadow: 2px 2px 4px rgba(0,0,0,0.5);'>
                                        XÁC NHẬN ĐẶT VÉ THÀNH CÔNG
                                    </p>
                                </td>
                            </tr>

                            <!-- Movie Title Banner -->
                            <tr>
                                <td style='background: linear-gradient(90deg, #ffd700 0%, #ffed4e 100%); padding: 15px 30px; text-align: center;'>
                                    <h2 style='color: #1a1a1a; margin: 0; font-size: 22px; font-weight: bold; text-transform: uppercase;'>
                                        🎥 {movieName}
                                    </h2>
                                </td>
                            </tr>

                            <!-- Mã vé -->
                            <tr>
                                <td style='padding: 30px; text-align: center; background-color: #ffffff;'>
                                    <table cellpadding='0' cellspacing='0' border='0' style='margin: 0 auto;'>
                                        <tr>
                                            <td style='background-color: #2c3e50; padding: 25px 40px; border-radius: 10px; border: 3px dashed #ffd700;'>
                                                <p style='color: #bdc3c7; margin: 0 0 8px 0; font-size: 14px; text-transform: uppercase; letter-spacing: 1px;'>Mã vé của bạn</p>
                                                <p style='color: #ffd700; margin: 0; font-size: 32px; font-weight: bold; font-family: Courier New, monospace; letter-spacing: 3px;'>
                                                    {ticketId}
                                                </p>
                                                <p style='color: #ecf0f1; margin: 8px 0 0 0; font-size: 13px;'>
                                                    Vui lòng xuất trình mã này tại quầy vé
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <!-- Thông tin khách hàng -->
                            <tr>
                                <td style='padding: 0 30px 20px 30px;'>
                                    <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background-color: #ecf0f1; border-radius: 10px; border-left: 5px solid #3498db;'>
                                        <tr>
                                            <td style='padding: 20px;'>
                                                <h3 style='color: #2c3e50; margin: 0 0 15px 0; font-size: 18px;'>
                                                    👤 Thông tin khách hàng
                                                </h3>
                                                <p style='margin: 8px 0; color: #34495e; font-size: 15px;'>
                                                    <strong>Họ tên:</strong> {customerName}
                                                </p>
                                                <p style='margin: 8px 0; color: #34495e; font-size: 15px;'>
                                                    <strong>Email:</strong> {toEmail}
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <!-- Thông tin đặt vé -->
                            <tr>
                                <td style='padding: 0 30px 20px 30px;'>
                                    <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background-color: #fff3cd; border-radius: 10px; border-left: 5px solid #ffc107;'>
                                        <tr>
                                            <td style='padding: 20px;'>
                                                <h3 style='color: #856404; margin: 0 0 15px 0; font-size: 18px;'>
                                                    🎫 Thông tin đặt vé
                                                </h3>
                                                <p style='margin: 10px 0; color: #856404; font-size: 15px;'>
                                                    <strong>Số lượng vé:</strong> {seats.Split(',').Length} vé
                                                </p>
                                                <p style='margin: 10px 0; color: #856404; font-size: 15px;'>
                                                    <strong>Số ghế:</strong> 
                                                    <span style='background-color: #ffd700; color: #1a1a1a; padding: 6px 12px; border-radius: 5px; font-weight: bold; display: inline-block; margin-top: 5px;'>
                                                        {seats}
                                                    </span>
                                                </p>
                                                <p style='margin: 10px 0; color: #856404; font-size: 15px;'>
                                                    <strong>Tổng tiền:</strong> 
                                                    <span style='color: #d39e00; font-size: 24px; font-weight: bold;'>
                                                        {totalAmount:N0} VNĐ
                                                    </span>
                                                </p>
                                                <p style='margin: 10px 0; color: #856404; font-size: 15px;'>
                                                    <strong>Ngày đặt:</strong> {DateTime.Now:dd/MM/yyyy HH:mm}
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <!-- Slogan -->
                            <tr>
                                <td style='padding: 0 30px 30px 30px; text-align: center;'>
                                    <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); border-radius: 10px;'>
                                        <tr>
                                            <td style='padding: 25px;'>
                                                <p style='color: #ffd700; margin: 0 0 10px 0; font-size: 20px; font-style: italic; font-weight: bold;'>
                                                    ✨ {_slogan} ✨
                                                </p>
                                                <p style='color: #ffffff; margin: 0; font-size: 15px;'>
                                                    ⏰ Vui lòng đến trước 15 phút để làm thủ tục vào rạp
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <!-- Footer -->
                            <tr>
                                <td style='background-color: #2c3e50; padding: 25px; text-align: center;'>
                                    <p style='color: #ecf0f1; margin: 0 0 12px 0; font-size: 15px; font-weight: bold;'>
                                        📍 Vui lòng mang email này đến quầy vé để nhận vé giấy
                                    </p>
                                    <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>
                                        📞 Hotline: <strong style='color: #ecf0f1;'>1950 1059</strong>
                                    </p>
                                    <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>
                                        📧 Email: <strong style='color: #ecf0f1;'>tienhungstusp@cinemaplus.com</strong>
                                    </p>
                                    <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>
                                        📍 Địa chỉ: 520 Đường Vào Tim Em, Quận Cam, TP.HCM
                                    </p>
                                    <p style='color: #95a5a6; margin: 15px 0 0 0; font-size: 11px;'>
                                        Email này được gửi tự động, vui lòng không trả lời.
                                    </p>
                                </td>
                            </tr>

                        </table>
                        
                    </td>
                </tr>
            </table>
            
        </div>
    </div>
    
</body>
</html>";
        }

        private string CreateEmailWithGradientBackground(
            string customerName,
            string movieName,
            string seats,
            string ticketId,
            decimal totalAmount,
            string toEmail)
        {
            return $@"
<!DOCTYPE html>
<html lang='vi'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
</head>
<body style='margin: 0; padding: 0; font-family: Arial, Helvetica, sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 40px 20px;'>
    
    <table width='100%' cellpadding='0' cellspacing='0' border='0'>
        <tr>
            <td align='center'>
                <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; border-radius: 15px; overflow: hidden; box-shadow: 0 10px 40px rgba(0,0,0,0.3);'>
                    
                    <!-- Header -->
                    <tr>
                        <td style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 40px 30px; text-align: center;'>
                            <h1 style='color: #ffffff; margin: 0; font-size: 36px; text-shadow: 2px 2px 4px rgba(0,0,0,0.3);'>
                                🎬 Cinema++
                            </h1>
                            <p style='color: #ffd700; margin: 15px 0 0 0; font-size: 20px; font-weight: bold;'>
                                XÁC NHẬN ĐẶT VÉ THÀNH CÔNG
                            </p>
                        </td>
                    </tr>

                    <!-- Movie Title -->
                    <tr>
                        <td style='background: linear-gradient(90deg, #ffd700 0%, #ffed4e 100%); padding: 15px 30px; text-align: center;'>
                            <h2 style='color: #1a1a1a; margin: 0; font-size: 22px; font-weight: bold;'>
                                🎥 {movieName}
                            </h2>
                        </td>
                    </tr>

                    <!-- Mã vé -->
                    <tr>
                        <td style='padding: 30px; text-align: center;'>
                            <table cellpadding='0' cellspacing='0' border='0' style='margin: 0 auto;'>
                                <tr>
                                    <td style='background-color: #2c3e50; padding: 25px 40px; border-radius: 10px; border: 3px dashed #ffd700;'>
                                        <p style='color: #bdc3c7; margin: 0 0 8px 0; font-size: 14px;'>Mã vé của bạn</p>
                                        <p style='color: #ffd700; margin: 0; font-size: 32px; font-weight: bold; font-family: Courier New, monospace; letter-spacing: 3px;'>
                                            {ticketId}
                                        </p>
                                        <p style='color: #ecf0f1; margin: 8px 0 0 0; font-size: 13px;'>
                                            Vui lòng xuất trình mã này tại quầy vé
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <!-- Thông tin khách hàng -->
                    <tr>
                        <td style='padding: 0 30px 20px 30px;'>
                            <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background-color: #ecf0f1; border-radius: 10px; border-left: 5px solid #3498db;'>
                                <tr>
                                    <td style='padding: 20px;'>
                                        <h3 style='color: #2c3e50; margin: 0 0 15px 0; font-size: 18px;'>👤 Thông tin khách hàng</h3>
                                        <p style='margin: 8px 0; color: #34495e;'><strong>Họ tên:</strong> {customerName}</p>
                                        <p style='margin: 8px 0; color: #34495e;'><strong>Email:</strong> {toEmail}</p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <!-- Thông tin vé -->
                    <tr>
                        <td style='padding: 0 30px 20px 30px;'>
                            <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background-color: #fff3cd; border-radius: 10px; border-left: 5px solid #ffc107;'>
                                <tr>
                                    <td style='padding: 20px;'>
                                        <h3 style='color: #856404; margin: 0 0 15px 0; font-size: 18px;'>🎫 Thông tin đặt vé</h3>
                                        <p style='margin: 10px 0; color: #856404;'><strong>Số lượng:</strong> {seats.Split(',').Length} vé</p>
                                        <p style='margin: 10px 0; color: #856404;'><strong>Số ghế:</strong> <span style='background-color: #ffd700; padding: 5px 10px; border-radius: 5px; font-weight: bold;'>{seats}</span></p>
                                        <p style='margin: 10px 0; color: #856404;'><strong>Tổng tiền:</strong> <span style='color: #d39e00; font-size: 24px; font-weight: bold;'>{totalAmount:N0} VNĐ</span></p>
                                        <p style='margin: 10px 0; color: #856404;'><strong>Ngày đặt:</strong> {DateTime.Now:dd/MM/yyyy HH:mm}</p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <!-- Slogan -->
                    <tr>
                        <td style='padding: 0 30px 30px 30px; text-align: center;'>
                            <table cellpadding='0' cellspacing='0' border='0' width='100%' style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); border-radius: 10px;'>
                                <tr>
                                    <td style='padding: 25px;'>
                                        <p style='color: #ffd700; margin: 0 0 10px 0; font-size: 20px; font-style: italic; font-weight: bold;'>✨ {_slogan} ✨</p>
                                        <p style='color: #ffffff; margin: 0; font-size: 15px;'>⏰ Vui lòng đến trước 15 phút để làm thủ tục vào rạp</p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <!-- Footer -->
                    <tr>
                        <td style='background-color: #2c3e50; padding: 25px; text-align: center;'>
                            <p style='color: #ecf0f1; margin: 0 0 12px 0; font-size: 15px; font-weight: bold;'>📍 Vui lòng mang email này đến quầy vé</p>
                            <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>📞 Hotline: <strong>1950 1059</strong></p>
                            <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>📧 tienhungstusp@cinemaplus.com</p>
                            <p style='color: #bdc3c7; margin: 6px 0; font-size: 14px;'>📍 520 Đường Vào Tim Em, Quận Cam, TP.HCM</p>
                            <p style='color: #95a5a6; margin: 15px 0 0 0; font-size: 11px;'>Email này được gửi tự động, vui lòng không trả lời.</p>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
    
</body>
</html>";
        }
    }
}
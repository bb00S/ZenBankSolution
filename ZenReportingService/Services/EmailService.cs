using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ZenReportingService.Models;

namespace ZenReportingService.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(IConfiguration configuration)
        {
            _smtpClient = new SmtpClient
            {
                Host = configuration["SmtpSettings:SmtpServer"],
                Port = Convert.ToInt32(configuration["SmtpSettings:Port"]),
                Credentials = new NetworkCredential(configuration["SmtpSettings:Username"], configuration["SmtpSettings:Password"]),
                EnableSsl = true 
            };
        }
        public async Task SendEmailAsync(string toEmail, byte[] pdfAttachment)
        {
            var mailMessage = new MailMessage("sender@example.com", toEmail)
            {
                Subject = "Daily Report",
                Body = "Please find attached the daily report in PDF format."
            };

            mailMessage.Attachments.Add(new Attachment(new MemoryStream(pdfAttachment), "DailyReport.pdf", "application/pdf"));

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}

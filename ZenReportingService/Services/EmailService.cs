using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace ZenReportingService.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body, Attachment attachment)
        {
            var smtpClient = new SmtpClient("your-smtp-server.com", 587)
            {
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage("your-email@example.com", toEmail, subject, body);
            mailMessage.Attachments.Add(attachment);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}

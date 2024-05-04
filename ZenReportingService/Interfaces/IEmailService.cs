using System.Net.Mail;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body, Attachment attachment);
}

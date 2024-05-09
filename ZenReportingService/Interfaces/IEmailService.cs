using System.Net.Mail;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, byte[] pdfAttachment);
}

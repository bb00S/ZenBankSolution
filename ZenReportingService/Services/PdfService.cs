using System;
using System.IO;
using ZenReportingService.Models;

namespace ZenReportingService.Services.PdfGeneration
{
    public class PdfService : IPdfService
    {
        public byte[] GeneratePdfReport(Client client, DateTime currentDate, decimal totalAmount)
        {

            var pdfContent = $"Client: {client.Name} ({client.Email})\n" +
                             $"Your daily statement of account\n" +
                             $"Current Date: {currentDate}\n" +
                             $"Total Amount: {totalAmount}\n";

            return System.Text.Encoding.UTF8.GetBytes(pdfContent);
        }
    }
}

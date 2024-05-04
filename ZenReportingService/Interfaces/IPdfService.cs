using ZenReportingService.Models;

public interface IPdfService
{
    byte[] GeneratePdfReport(Client client, DateTime currentDate, decimal totalAmount);
}


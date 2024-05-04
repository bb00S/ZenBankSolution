namespace ZenReportingService.Models
{
    public class ReportData
    {
        public DateTime CurrentDate { get; set; }
        public List<Transaction> Transactions { get; set; }
        public decimal TotalSum { get; set; }

    }

    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

    }
}

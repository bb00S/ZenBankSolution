namespace ZenCoreService.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

using Swashbuckle.AspNetCore.Annotations;

namespace ZenCoreService.Models
{
    [SwaggerSchema("ZenCoreServiceTransaction")]
    public class ZenTransaction
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

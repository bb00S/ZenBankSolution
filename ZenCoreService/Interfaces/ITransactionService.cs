using System.Collections.Generic;
using ZenCoreService.Models;

namespace ZenCoreService.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
    }
}

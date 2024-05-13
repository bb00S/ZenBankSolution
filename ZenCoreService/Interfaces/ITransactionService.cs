using System.Collections.Generic;
using ZenCoreService.Models;

namespace ZenCoreService.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<ZenTransaction> GetAllTransactions();
        ZenTransaction GetTransactionById(int ID);
        ZenTransaction CreateTransaction(ZenTransaction transaction);
    }
}

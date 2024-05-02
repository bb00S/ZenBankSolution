using System.Collections.Generic;
using System.Linq;
using ZenCoreService.Data;
using ZenCoreService.Interfaces;
using ZenCoreService.Models;

namespace ZenCoreService.Services.TransactionServices
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _dbContext;

        public TransactionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _dbContext.Transactions.ToList();
        }

    }
}

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

        public IEnumerable<ZenTransaction> GetAllTransactions()
        {
            return _dbContext.Transactions.ToList();
        }

        public ZenTransaction GetTransactionById(int ID) 
        {
            return _dbContext.Transactions.FirstOrDefault(t => t.ID == ID);
        }


        public ZenTransaction CreateTransaction(ZenTransaction transaction)
        {
            
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            return transaction;
        }
    }
}

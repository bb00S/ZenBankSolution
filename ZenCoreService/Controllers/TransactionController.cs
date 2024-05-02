using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using ZenCoreService.Interfaces;

namespace ZenCoreService.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

    }
}

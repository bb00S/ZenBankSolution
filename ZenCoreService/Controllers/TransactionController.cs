using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using ZenCoreService.Interfaces;

namespace ZenCoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }

        [HttpGet("{ID}", Name = "GetTransactionById")]
        public ActionResult<Transaction> GetTransactionById(int ID)
        {
            var transaction = _transactionService.GetTransactionById(ID);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }


        [HttpPost]
        public ActionResult<ZenCoreService.Models.ZenTransaction> CreateTransaction(ZenCoreService.Models.ZenTransaction transaction)
        {
            var createdTransaction = _transactionService.CreateTransaction(transaction);
            return CreatedAtAction("GetTransactionById", new { ID = createdTransaction.ID }, createdTransaction);
        }


    }
}

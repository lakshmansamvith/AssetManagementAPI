using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Manager;
using AssetManagementAPI.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionManager transactionManager, ILogger<TransactionController> logger)
        {
            _transactionManager = transactionManager;
            _logger = logger;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            try
            {
                var transactions = await _transactionManager.GetTransactionsAsync();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get transactions from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            try
            {
                var transaction = await _transactionManager.GetTransactionById(id);
                if (transaction == null)
                {
                    return NotFound("Transaction not found.");
                }
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to get transaction by ID ({id}) from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<IActionResult> MakeTransaction([FromBody] Transaction transaction)
        {
            try
            {
                await _transactionManager.MakeTransaction(transaction);
                return Ok("Transaction made successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Transaction could not be made from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

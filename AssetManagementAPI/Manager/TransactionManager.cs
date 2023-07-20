using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Manager;
using AssetManagementAPI.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementAPI.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly ILogger<TransactionManager> _logger;

        public TransactionManager(ITransactionRepo transactionRepo, ILogger<TransactionManager> logger)
        {
            _transactionRepo = transactionRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            try
            {
                return await _transactionRepo.GetTransactionsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get transactions from the manager.");
                throw;
            }
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            try
            {
                return await _transactionRepo.GetTransactionById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to get transaction by ID ({id}) from the manager.");
                throw;
            }
        }

        public async Task MakeTransaction(Transaction transaction)
        {
            try
            {
                await _transactionRepo.MakeTransaction(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Transaction could not be made from the manager.");
                throw;
            }
        }
    }
}

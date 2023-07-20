using Dapper;
using AssetManagementAPI.Data.Models;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System;


namespace AssetManagementAPI.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly IDbConnection _connection; 
        private readonly ILogger<TransactionRepo> _logger;

        public TransactionRepo(IDbConnection connection, ILogger<TransactionRepo> logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {

            try
            {
                var query = "am.GetTransactions";
                var result = await _connection.QueryAsync<Transaction>(query);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); 
                throw;
            }
            
        }

        public async Task<Transaction> GetTransactionById(int Id)
        {
            try
            {
                var query = "am.GetTransactionsById";
                var result = await _connection.QuerySingleOrDefaultAsync<Transaction>(query, Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

            

        }

        public async Task MakeTransaction(Transaction transaction)
        {
            try
            {
                var query = "am.MakeTransaction";
                var result = await _connection.ExecuteAsync(query,
                    new
                    {
                        ID = transaction.Id,
                        AssetID = transaction.AssetId,
                        BuyerID = transaction.BuyerId,
                        SellerID = transaction.SellerId,
                        TransactionType = transaction.TransactionType,
                        TransctionDate = transaction.TransactionDate,
                    });
            }
            catch (Exception ex) { 
                _logger.LogError(ex, ex.Message); 
                throw; 
            
            }
            
        }

    }
}

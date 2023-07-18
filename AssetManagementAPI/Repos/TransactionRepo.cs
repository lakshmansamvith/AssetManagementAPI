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

        public TransactionRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            var query = "am.GetTransactions";
            var result = await _connection.QueryAsync<Transaction>(query);
            return result; 
        }

        public async Task<Transaction> GetTransactionById(int Id)
        {
            var query = "am.GetTransactionsById";
            var result = await _connection.QuerySingleOrDefaultAsync<Transaction>(query, Id);
            return result;

        }

        public async Task MakeTransaction(Transaction transaction)
        {

            var query = "am.MakeTransaction"; 
            var result = await _connection.ExecuteAsync(query, 
                new {
                    ID = transaction.Id, 
                    AssetID = transaction.AssetId,
                    BuyerID = transaction.BuyerId, 
                    SellerID = transaction.SellerId,
                    TransactionType = transaction.TransactionType,
                    TransctionDate = transaction.TransactionDate,
            });
        }

    }
}

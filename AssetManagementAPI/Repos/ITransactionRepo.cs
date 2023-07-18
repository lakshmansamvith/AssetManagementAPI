using AssetManagementAPI.Data.Models; 

namespace AssetManagementAPI.Repos
{
    public interface ITransactionRepo
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();

        Task<Transaction> GetTransactionById(int Id); 

        Task MakeTransaction(Transaction transaction);
    }
}

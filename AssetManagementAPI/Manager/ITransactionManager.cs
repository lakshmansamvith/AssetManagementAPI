using AssetManagementAPI.Data.Models;
namespace AssetManagementAPI.Manager
{
    public interface ITransactionManager
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();

        Task<Transaction> GetTransactionById(int Id);

        Task MakeTransaction(Transaction transaction);
    }
}

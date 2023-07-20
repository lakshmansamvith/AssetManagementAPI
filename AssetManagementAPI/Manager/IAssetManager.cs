using AssetManagementAPI.Data.Models;
namespace AssetManagementAPI.Manager
{
    public interface IAssetManager
    {
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task AddAssetAsync(Asset asset);
        Task UpdateAssetAsync(Asset asset);
        Task DeleteAssetAsync(int id);
    }
}

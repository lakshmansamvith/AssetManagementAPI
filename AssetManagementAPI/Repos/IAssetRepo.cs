using AssetManagementAPI.Data.Models;
namespace AssetManagementAPI.Repos
{
    public interface IAssetRepo
    {
        Task<IEnumerable<Asset>> GetAllAssetsAsync();
        Task AddAssetAsync(Asset asset);
        Task UpdateAssetAsync(Asset asset);
        Task DeleteAssetAsync(int id);
    }

}

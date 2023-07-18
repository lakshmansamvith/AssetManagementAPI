using Dapper;
using AssetManagementAPI.Data.Models;
using System.Data;

namespace AssetManagementAPI.Repos
{
    public class AssetRepo : IAssetRepo
    {
        private readonly IDbConnection _connection;

        public AssetRepo(IDbConnection connection)
        {
            _connection = connection;
        }

       

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            var query = "am.GetAllAssets";

            var assets = await _connection.QueryAsync<Asset>(query);

            return assets;
        }

        public async Task AddAssetAsync(Asset asset)
        {
            var query = "am.AddAsset";

            await _connection.ExecuteAsync(query, new { Name = asset.Name, Description = asset.Description, Price = asset.Price, @OwnerID = asset.OwnerId });
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            var query = "am.UpdateAsset";

            await _connection.ExecuteAsync(query, new { ID = asset.Id, Name = asset.Name, Description = asset.Description, Price = asset.Price });
        }

        public async Task DeleteAssetAsync(int id)
        {
            var query = "am.DeleteAsset";

            await _connection.ExecuteAsync(query, new { id });
        }
    }

}

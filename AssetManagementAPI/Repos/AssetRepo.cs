using Dapper;
using AssetManagementAPI.Data.Models;
using System.Data;

namespace AssetManagementAPI.Repos
{
    public class AssetRepo : IAssetRepo
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<AssetRepo> _logger; 

        public AssetRepo(IDbConnection connection, ILogger<AssetRepo> logger)
        {
            _connection = connection;
            _logger = logger;
        }

       

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            try
            {
                var query = "am.GetAllAssets";

                var assets = await _connection.QueryAsync<Asset>(query);

                return assets;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all assets");
                throw;
            }
            
        }

        public async Task AddAssetAsync(Asset asset)
        {
            try
            {
                var query = "am.AddAsset";

                await _connection.ExecuteAsync(query, new { Name = asset.Name, Description = asset.Description, Price = asset.Price, @OwnerID = asset.OwnerId });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be added");
                throw;
            }
            
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            try
            {
                var query = "am.UpdateAsset";

                await _connection.ExecuteAsync(query, new { ID = asset.Id, Name = asset.Name, Description = asset.Description, Price = asset.Price });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be updated");
                throw;
            }
            
        }

        public async Task DeleteAssetAsync(int id)
        {
            try
            {

                var query = "am.DeleteAsset";

                await _connection.ExecuteAsync(query, new { id });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
                   }
    }

}

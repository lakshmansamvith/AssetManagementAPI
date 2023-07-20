using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Manager;
using AssetManagementAPI.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementAPI.Managers
{
    public class AssetManager : IAssetManager
    {
        private readonly IAssetRepo _assetRepo;
        private readonly ILogger<AssetManager> _logger;

        public AssetManager(IAssetRepo assetRepo, ILogger<AssetManager> logger)
        {
            _assetRepo = assetRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
        {
            try
            {
                return await _assetRepo.GetAllAssetsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all assets from the manager.");
                throw;
            }
        }

        public async Task AddAssetAsync(Asset asset)
        {
            try
            {
                await _assetRepo.AddAssetAsync(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be added from the manager.");
                throw;
            }
        }

        public async Task UpdateAssetAsync(Asset asset)
        {
            try
            {
                await _assetRepo.UpdateAssetAsync(asset);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be updated from the manager.");
                throw;
            }
        }

        public async Task DeleteAssetAsync(int id)
        {
            try
            {
                await _assetRepo.DeleteAssetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be deleted from the manager.");
                throw;
            }
        }
    }
}

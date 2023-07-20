using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Manager;
using AssetManagementAPI.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetManager _assetManager;
        private readonly ILogger<AssetController> _logger;

        public AssetController(IAssetManager assetManager, ILogger<AssetController> logger)
        {
            _assetManager = assetManager;
            _logger = logger;
        }

        // GET: api/Asset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAllAssets()
        {
            try
            {
                var assets = await _assetManager.GetAllAssetsAsync();
                return Ok(assets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all assets from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/Asset
        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] Asset asset)
        {
            try
            {
                await _assetManager.AddAssetAsync(asset);
                return Ok("Asset added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be added from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/Asset/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(int id, [FromBody] Asset asset)
        {
            try
            {
                if (id != asset.Id)
                {
                    return BadRequest("Invalid asset ID.");
                }

                await _assetManager.UpdateAssetAsync(asset);
                return Ok("Asset updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be updated from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/Asset/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            try
            {
                await _assetManager.DeleteAssetAsync(id);
                return Ok("Asset deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Asset could not be deleted from the controller.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

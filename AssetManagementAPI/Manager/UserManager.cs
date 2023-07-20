using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Manager;
using AssetManagementAPI.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementAPI.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<UserManager> _logger;

        public UserManager(IUserRepo userRepo, ILogger<UserManager> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _userRepo.GetUserById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get user by ID from the manager.");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _userRepo.GetUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all users from the manager.");
                throw;
            }
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _userRepo.AddUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User could not be added from the manager.");
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                await _userRepo.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User could not be deleted from the manager.");
                throw;
            }
        }

        public async Task RegisterUser(User user)
        {
            try
            {
                await _userRepo.RegisterUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User could not be registered from the manager.");
                throw;
            }
        }
    }
}

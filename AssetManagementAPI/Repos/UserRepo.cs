using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Repos;
using Dapper;
using System.Collections.Generic;
using System.Data;

public class UserRepo : IUserRepo
{
    private readonly IDbConnection _connection;
    private readonly ILogger<IUserRepo> _logger;

    public UserRepo(IDbConnection connection, ILogger<IUserRepo> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var user = await _connection.QuerySingleAsync<User>(
            "am.GetUserProfile",
            new { id });

            return user;

        }
        catch (Exception ex) { _logger.LogError(ex, ex.Message); throw; }

    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        try
        {
            var users = await _connection.QueryAsync<User>(
        "am.GetAllUsers");

            return users;
        }
        catch (Exception ex) { _logger.LogError(ex, ex.Message); throw; }
        
    }

    public async Task AddUser(User user)
    {

        try
        {
            await _connection.ExecuteAsync(
             "am.AddUser",
             new
             {
                 FirstName = user.FirstName,
                 LastName = user.LastName,
                 UserName = user.Username,
                 Password = user.Password,
                 Address = user.Address,
                 Email = user.Email,
                 Role = user.Role,
             });
        }
        catch (Exception ez)
        {
               _logger.LogError(ez, ez.Message);
            throw;
        }
        
    }


    public async Task DeleteUserAsync(int id)
    {
        try
        {
            await _connection.ExecuteAsync(
            "am.DeleteUser",
            new { id });
        }

        catch(Exception ex)
        {
            _logger.LogError(ex, ex.Message); 
            throw;
        }

        
    }

    public async Task RegisterUser(User user)
    {
        try
        {
            await _connection.ExecuteAsync(
            "am.RegisterUser",
            new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Password = user.Password,
                Address = user.Address,
                Email = user.Email,
                Role = user.Role,
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        
    }
}

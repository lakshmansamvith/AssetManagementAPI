using AssetManagementAPI.Data.Models;
using AssetManagementAPI.Repos;
using Dapper;
using System.Collections.Generic;
using System.Data;

public class UserRepo : IUserRepo
{
    private readonly IDbConnection _connection;

    public UserRepo(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<User> GetUserById(int id)
    {
        var user = await _connection.QuerySingleAsync<User>(
            "am.GetUserProfile",
            new { id });

        return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _connection.QueryAsync<User>(
            "am.GetAllUsers");

        return users;
    }

    public async Task AddUser(User user)
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


    public async Task DeleteUserAsync(int id)
    {
        await _connection.ExecuteAsync(
            "am.DeleteUser",
            new { id });
    }

    public async Task RegisterUser(User user)
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
}

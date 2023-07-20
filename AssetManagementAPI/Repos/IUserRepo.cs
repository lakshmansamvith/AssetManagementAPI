using System;
using System.Collections.Generic;
using System.Text;

using AssetManagementAPI.Data.Models;
namespace AssetManagementAPI.Repos
{   
    public interface IUserRepo
    {
        Task<User> GetUserById(int id);

        Task<IEnumerable<User>> GetUsers();

        Task AddUser(User user);

        Task DeleteUserAsync(int id);

        Task RegisterUser(User user); 
    }

}

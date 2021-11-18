using KameGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Interfaces
{
    public interface IUserRepo
    {
        Task<UserModel> GetUserRepo(int id);

        Task<UserModel> UserLoginRepo(string username, string password);

        Task<UserModel> CreateUserRepo(UserModel user);
    }
}

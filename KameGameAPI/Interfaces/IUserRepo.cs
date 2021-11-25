using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        Task<ActionResult<UserModel>> UpdateUserRepo(int id, UserModel user);
    }
}

using KameGameAPI.DTOs;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetUserService(int id);

        Task<int> UserLoginService(string username, string password);

        Task<UserResp> CreateUserService(UserModel user);
    }
}

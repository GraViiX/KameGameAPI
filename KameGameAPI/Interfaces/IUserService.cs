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
        Task<UserResp> GetUserService(int id);

        Task<LoginResponse> UserLoginService(string username, string password);

        Task<UserResp> CreateUserService(UserModel user);
        Task<ActionResult<UserModel>> UpdateUserService(int id, UserModel user);

        Task<ActionResult> DeleteUserService(int id);
    }
}

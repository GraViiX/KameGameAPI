using KameGameAPI.DTOs;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _context;

        public UserService(IUserRepo context)
        {
            _context = context;
        }

        public async Task<UserResp> GetUserService(int id)
        {
            UserModel user = await _context.GetUserRepo(id);
            if (user == null)
            {
                return null;
            }
            UserResp userResp = new UserResp()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                UTLF = user.UTLF,
                RoleId = user.RoleId,
                role = user.role,
                AddressId = (int)user.AddressId,
                address = user.address
            };
            return userResp;
        }

        public async Task<int> UserLoginService(string username, string password)
        {
            UserModel userModel = await _context.UserLoginRepo(username, password);

            return userModel.UserId;
        }

        public async Task<UserResp> CreateUserService(UserModel user)
        {
            UserModel createdUser = await _context.CreateUserRepo(user);

            if (createdUser == null)
            {
                return null;
            }
            UserResp userResp = new UserResp() { 
                UserId = createdUser.UserId, UserName = createdUser.UserName, 
                Email = createdUser.Email, UTLF = user.UTLF, 
                RoleId = createdUser.RoleId, role = createdUser.role, 
                AddressId = (int)createdUser.AddressId, address = createdUser.address 
            };
            return userResp;
        }

        public async Task<ActionResult<UserModel>> UpdateUserService(int id, UserModel user)
        {
            return await _context.UpdateUserRepo(id, user);
        }
    }
}

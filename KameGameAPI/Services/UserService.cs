using KameGameAPI.DTOs;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
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

        public async Task<UserModel> GetUserService(int id)
        {
            return await _context.GetUserRepo(id);
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
    }
}

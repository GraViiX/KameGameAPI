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

        public async Task<int> UserLoginService(string username, string password)
        {
            UserModel userModel = await _context.UserLoginRepo(username, password);

            return userModel.UserId;
        }
    }
}

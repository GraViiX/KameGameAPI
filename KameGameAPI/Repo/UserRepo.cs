using KameGameAPI.Database;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext context) 
        {
            _context = context;
        }

        public async Task<UserModel> GetUserRepo(int id)
        {
            var user = await _context.users.FindAsync(id);

            return user;
        }

        public Task<UserModel> UserLoginRepo(string username, string password)
        {
            return Task.FromResult(_context.users.Where(u => u.UserName == username && u.UPassword == password).FirstOrDefault());
        }

        public async Task<UserModel> CreateUserRepo(UserModel user)
        {
            // Create address
            // get address id
            // parse address id into checkusername
            // Er ikke nødvendigt!

            UserModel checkusername = await _context.users.FirstOrDefaultAsync(obj => obj.UserName == user.UserName);
            if (checkusername != null)
            {
                return null;
            }
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return await GetUserRepo(user.UserId);
        }
    }
}

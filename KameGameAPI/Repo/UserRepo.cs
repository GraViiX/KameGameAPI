using KameGameAPI.Database;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
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

        public Task<UserModel> UserLoginRepo(string username, string password)
        {
            return Task.FromResult(_context.users.Where(u => u.UserName == username && u.UPassword == password).FirstOrDefault());
        }
    }
}

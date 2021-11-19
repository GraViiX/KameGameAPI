using KameGameAPI.Database;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Repo
{
    public class PostCodeRepo : IPostCodeRepo
    {
        private readonly DatabaseContext _context;

        public PostCodeRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<PostcodeModel>>> GetpostcodesRepo()
        {
            return await _context.postcodes.ToListAsync();
        }
    }
}

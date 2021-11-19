using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Services
{
    public class PostCodeService : IPostCodeService
    {
        private readonly IPostCodeRepo _context;

        public PostCodeService(IPostCodeRepo context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<PostcodeModel>>> GetpostcodesService()
        {
            return await _context.GetpostcodesRepo();
        }
    }
}

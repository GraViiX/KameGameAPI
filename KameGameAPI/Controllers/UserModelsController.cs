using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KameGameAPI.Database;
using KameGameAPI.Models;
using KameGameAPI.Interfaces;

namespace KameGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserModelsController : ControllerBase
    {
        private readonly IUserService _context;

        public UserModelsController(IUserService context)
        {
            _context = context;
        }

        // GET: api/UserModels
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserModel>>> Getusers()
        //{
        //    return await _context.users.ToListAsync();
        //}

        //// GET: api/UserModels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserModel>> GetUserModel(int id)
        //{
        //    var userModel = await _context.users.FindAsync(id);

        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return userModel;
        //}

        //// PUT: api/UserModels/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserModel(int id, UserModel userModel)
        //{
        //    if (id != userModel.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/UserModels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserModel>> PostUserModel(UserModel userModel)
        //{
        //    _context.users.Add(userModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserModel", new { id = userModel.UserId }, userModel);
        //}

        [HttpPost("Login")]
        public async Task<ActionResult<int>> Login(UserModel user)
        {
            return Ok(await _context.UserLoginService(user.UserName, user.UPassword));            
        }


        //// DELETE: api/UserModels/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserModel(int id)
        //{
        //    var userModel = await _context.users.FindAsync(id);
        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.users.Remove(userModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserModelExists(int id)
        //{
        //    return _context.users.Any(e => e.UserId == id);
        //}
    }
}

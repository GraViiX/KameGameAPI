﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KameGameAPI.Database;
using KameGameAPI.Models;
using KameGameAPI.Interfaces;
using KameGameAPI.DTOs;

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
        public async Task<ActionResult<LoginResponse>> Login(UserModel user)
        {
            try
            {
                if (user.UPassword == "" || user.UserName == "")
                {
                    return BadRequest();
                }
                
                return Ok(await _context.UserLoginService(user.UserName, user.UPassword));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }  
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserResp>> CreateUser(UserModel user)
        {
            UserResp createUser = await _context.CreateUserService(user);

            try
            {
                if (createUser == null)
                {
                    return BadRequest("Username Taken");
                }
                else
                {
                    return Ok(createUser);
                }
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpPost("UpdateUser/{id}")]
        public async Task<ActionResult<UserModel>> PutUser(int id, UserModel user)
        {

            try
            {
                if (id == 0 || user == null)
                {
                    return BadRequest();
                }
                
                return Ok(await _context.UpdateUserService(id, user));
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<UserResp>> GetUserById(int id)
        {
            try
            {
                if (await _context.GetUserService(id) == null)
                {
                    return BadRequest("User doesn't exist");
                }
                else
                {
                    return Ok(await _context.GetUserService(id));
                }


            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                UserModel createUser = await _context.DeleteUserService(id);
                if(createUser == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        //private bool UserModelExists(int id)
        //{
        //    return _context.users.Any(e => e.UserId == id);
        //}
    }
}

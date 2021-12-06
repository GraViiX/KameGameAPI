using KameGameAPI.Database;
using KameGameAPI.Encryption;
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
    public class UserRepo : ControllerBase, IUserRepo
    {
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext context) 
        {
            _context = context;
        }
        SALT salt = new SALT();

        public async Task<UserModel> GetUserRepo(int id)
        {
            var user = await _context.users.FindAsync(id);
            var user1 = await _context.users.Include(h => h.role).OrderBy(g => g.RoleId).ToListAsync();
            var user2 = await _context.users.Include(h => h.address).OrderBy(g => g.AddressId).ToListAsync();
            var user3 = await _context.addresses.Include(h => h.postCode).OrderBy(g => g.PostCodeId).ToListAsync();
            return user;
        }

        public Task<UserModel> UserLoginRepo(string username, string password)
        {
            return Task.FromResult(_context.users.Where(u => u.UserName == username && u.UPassword == Convert.ToBase64String(salt.GenerateSalt(password))).FirstOrDefault());
        }

        public async Task<UserModel> CreateUserRepo(UserModel user)
        {
            // Create address
            // get address id
            // parse address id into checkusername
            // Er ikke nødvendigt!

            user.UPassword = Convert.ToBase64String(salt.GenerateSalt(user.UPassword));

            UserModel checkusername = await _context.users.FirstOrDefaultAsync(obj => obj.UserName == user.UserName);
            if (checkusername != null)
            {
                return null;
            }
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return await GetUserRepo(user.UserId);
        }

        public async Task<ActionResult<UserModel>> UpdateUserRepo(int id, UserModel user)
        {
            /*_context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _context.users.Where(u => u.UserId == id).FirstOrDefault();*/
            if (id != user.UserId)
            {
                return BadRequest();
            }

            if (user.UPassword == "" || user.UPassword == null){ }
            else
            {
                user.UPassword = Convert.ToBase64String(salt.GenerateSalt(user.UPassword));
            }
            
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.users.Any(obj => obj.UserId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(Task.FromResult(_context.users.Where(u => u.UserId == id).FirstOrDefault())); // hmm, giver Task.FromResult det vi vil have? Altså de opdaterede oplysninger.

            //return NoContent(); // returner nye bruger oplysninger


            #region OldCode
            //UserModel updateUser = await _context.users.FirstOrDefaultAsync(obj => obj.UserId == id);
            //if (updateUser != null)
            //{
            //    updateUser.UserName = user.UserName;
            //    updateUser.UPassword = user.UPassword;
            //    await _context.SaveChangesAsync();
            //}
            //return updateUser;



            //UserModel activeUser = await _context.users.FindAsync(id);
            //if (user.UserName == "" || user.UserName == null)
            //{
            //    user.UserName = activeUser.UserName;
            //}
            //if (user.UPassword == "" || user.UPassword == null)
            //{
            //    user.UPassword = activeUser.UPassword;
            //}
            ////else
            ////{
            ////    user.Password = Convert.ToBase64String(SALT.GenerateSalt(user.Password));
            ////}
            //if (user.Email == "" || user.Email == null)
            //{
            //    user.Email = activeUser.Email;
            //}
            //user.role = activeUser.role;
            //user.UserID = id;

            //if (!UsernameExists(user.Username) || activeUser.Username == user.Username)
            //{
            //    _context.Entry(user).State = EntityState.Modified;
            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!UserExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}
            //else
            //{
            //    return BadRequest("Username already exists");
            //}
            //return NoContent();
            #endregion
        }

        public async Task<ActionResult> DeleteUserRepo(int id)
        {
            var userModel = await _context.users.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.users.Remove(userModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

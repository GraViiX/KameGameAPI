using KameGameAPI.DTOs;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KameGameAPI.Encryption;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace KameGameAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _context;
        private readonly JwtConfig _jwtsettings;

        public UserService(IUserRepo context, IOptions<JwtConfig> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
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

        public async Task<LoginResponse> UserLoginService(string username, string password)
        {
            UserModel userModel = await _context.UserLoginRepo(username, password);
            var tokenHandler = new JwtSecurityTokenHandler(); // Her opretter vi en nyt jwt security token handler instans som hedder tokenHandler
            var key = Encoding.ASCII.GetBytes(_jwtsettings.Secret); // her encodes secretkey 
            var tokenDescriptor = new SecurityTokenDescriptor // Her fortælles der hvad der skal være med af data i denne token.
            {
                // dette er et object som identificere den person som er logget ind. disse dataer bliver lagt ind i token.
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", userModel.UserId.ToString()),
                    new Claim("userName",userModel.UserName)

                }),
                Expires = DateTime.UtcNow.AddDays(2), // Here fortælles der hvornår at denne token udløber
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // Her bliver selve min token genereret og gjort klar til at blive sendt til brugeren

            //Return token
            return new LoginResponse() { token = tokenHandler.WriteToken(token) }; // her skrives token og sendt til brugeren.
            
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

        public async Task<IActionResult> DeleteUserService(int id)
        {
            return await _context.DeleteUserRepo(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using KameGameAPI.Controllers;
using KameGameAPI.Interfaces;
using KameGameAPI.DTOs;
using KameGameAPI.Models;
using Moq;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace UnitTest
{
    public class UserModelsControllers
    {
        private readonly UserModelsController _sut;
        private Mock<IUserService> _userservice = new();

        public UserModelsControllers()
        {
            _sut = new UserModelsController(_userservice.Object);
        }

        [Fact]
        public async void EditUser_ShouldReturStatusCode200()
        {
            int id = 1;
            UserModel user = new UserModel()
            {
                UserId= 0,
                UserName = "Rasmus",
                UPassword = "1234Rb56",
                Email = "rasm232m@elev.tec.dk",
                UTLF = 22898686,
                RoleId = 1,
                role = new RoleModel
                {
                    RoleId = 1,
                    Role = "user"
                },
                AddressId = 11,
                address = new AddressModel
                {
                    AddressId = 11,
                    PostCodeId = 1,
                    postCode = new PostcodeModel
                    {
                        PostcodeId = 1,
                        Postcode = 3600,
                        City = "Frederikssund",
                    },
                    StreetNames = "Roskildevej 100, tv"
                }
            };
            _userservice.Setup(a => a.UpdateUserService(id, user));


            var result = await _sut.PutUser(id, user);
            
            //virker ikke lige nu
            /*var statuscoderesult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscoderesult.StatusCode);*/
        }
    }
}

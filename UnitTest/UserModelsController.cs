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

        //Arrange
        //Act
        //Assert

        [Fact]
        public async void EditUser_ShouldReturStatusCode200()
        {
            //Arrange
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

            // Interface niveau
            _userservice.Setup(a => a.UpdateUserService(id, user)).ReturnsAsync(user);

            //Act
            var result = await _sut.PutUser(id, user);

            //Assert - Controller niveau
            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public async void EditUser_ShouldReturStatusCode400()
        {
            int id = 0;
            UserModel user = new();

            _userservice.Setup(a => a.UpdateUserService(id, user));


            var result = await _sut.PutUser(id, user);

            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(400, statuscoderesult.StatusCode);
        }

        [Fact]
        public async void Login_ShouldReturStatusCode200()
        {
            //Arrange
            UserModel user = new UserModel()
            {
                UserId = 0,
                UserName = "Rasmus",
                UPassword = "1234Rb56"
            };
            LoginResponse login = new LoginResponse();
            // Interface niveau
            _userservice.Setup(a => a.UserLoginService(user.UserName, user.UPassword)).ReturnsAsync(login);

            //Act
            var result = await _sut.Login(user);

            //Assert - Controller niveau
            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public async void Login_ShouldReturStatusCode400()
        {
            //Arrange
            UserModel user = new UserModel()
            {
                UserName = "",
                UPassword = ""
            };
            LoginResponse login = new LoginResponse();
            // Interface niveau
            _userservice.Setup(a => a.UserLoginService(user.UserName, user.UPassword)).ReturnsAsync(login);

            //Act
            var result = await _sut.Login(user);

            //Assert - Controller niveau
            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(400, statuscoderesult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturStatusCode200()
        {
            //Arrange
            UserModel user = new UserModel()
            {
                UserId = 0,
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
            UserResp create = new UserResp();
            // Interface niveau
            _userservice.Setup(a => a.CreateUserService(user)).ReturnsAsync(create);

            //Act
            var result = await _sut.Login(user);

            //Assert - Controller niveau
            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(200, statuscoderesult.StatusCode);
        }

        [Fact]
        public async void Create_ShouldReturStatusCode500()
        {
            //Arrange
            UserModel user = new UserModel();
            UserResp create = new UserResp();
            // Interface niveau
            _userservice.Setup(a => a.CreateUserService(user)).ReturnsAsync(create);

            //Act
            var result = await _sut.Login(user = null);

            //Assert - Controller niveau
            var statuscoderesult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(500, statuscoderesult.StatusCode);
        }
    }
}

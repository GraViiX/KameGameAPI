using KameGameAPI.Controllers;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class PostcodeControllerTest
    {

        private readonly PostcodeModelsController _sut;
        private Mock<IPostCodeService> _postcodeservice = new(); // TEMP SERVICE FOR TESTING.


        //CONSTRUCTOR
        public PostcodeControllerTest()
        {
            _sut = new PostcodeModelsController(_postcodeservice.Object);
        }

        [Fact]
        public async void getAllPostcodes_Ok()
        {
            //ARRANGE
            List<PostcodeModel> postcode = new List<PostcodeModel>();
            _postcodeservice.Setup(a => a.GetpostcodesService()).ReturnsAsync(postcode);

            //ACT
            var result = await _sut.Getpostcodes();

            //ASSERT
            var statusCodeResult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAllPostcodes_InternalServerError()
        {
            //ARRANGE
            _postcodeservice.Setup(a => a.GetpostcodesService()).ReturnsAsync(() => null);

            //ACT
            var result = await _sut.Getpostcodes();

            //ASSERT
            var statusCodeResult = (IStatusCodeActionResult)result.Result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KameGameAPI.Controllers;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Xunit;

namespace UnitTest
{
    public class ShopModelsControllerTest
    {
        private readonly ShopModelsController _smct;
        private readonly Mock<IShopService> _shopService = new();

        public ShopModelsControllerTest()
        {
            _smct = new ShopModelsController(_shopService.Object);
        }

        [Fact]
        public async void SavePurchases_ElementsCreated()
        {
            List<ShopModel> listOfShops = new List<ShopModel>()
            {
                new ShopModel { UserId = 12, ItemId = 8907755, Amount = 3, Bought = "07-12-2021 11:02:00"},
                new ShopModel { UserId = 12, ItemId = 2107755, Amount = 2, Bought = "07-12-2021 11:02:00"}
            };
            _shopService.Setup(shop => shop.SavePurchasesService(listOfShops)).ReturnsAsync(listOfShops);
            var result = await _smct.SavePurchases(listOfShops);

            var statusCodeResult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void SavePurchases_WhenNoElementsExists()
        {
            List<ShopModel> listOfShops = new();
            _shopService.Setup(shop => shop.SavePurchasesService(listOfShops)).ReturnsAsync(listOfShops);
            var result = await _smct.SavePurchases(listOfShops);

            var statusCodeResult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void SavePurchases_NotExisting()
        {
            List<ShopModel> listOfShops = new();
            _shopService.Setup(shop => shop.SavePurchasesService(listOfShops)).ReturnsAsync(() => null);
            var result = await _smct.SavePurchases(listOfShops);

            var statusCodeResult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void SavePurchases_ExceptionIsRaised()
        {
            List<ShopModel> listOfShops = new();
            _shopService.Setup(shop => shop.SavePurchasesService(listOfShops)).ReturnsAsync(() => throw new Exception("Exception Test"));
            var result = await _smct.SavePurchases(listOfShops);

            var statusCodeResult = (IStatusCodeActionResult)result.Result;

            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}

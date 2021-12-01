using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Services
{
    public class ShopService : IShopService
    {
        private IShopRepo _context;
        public ShopService(IShopRepo context)
        {
            _context = context;
        }
        public async Task<List<ShopModel>> SavePurchasesService(List<ShopModel> basket)
        {
            return await _context.SavePurchasesRepo(basket);
        }
    }
}

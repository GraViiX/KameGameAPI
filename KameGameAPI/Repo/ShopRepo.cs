using KameGameAPI.Database;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Repo
{
    public class ShopRepo : IShopRepo
    {
        private DatabaseContext _context;
        public ShopRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ShopModel>> SavePurchasesRepo(List<ShopModel> basket)
        {
            try
            {
                foreach (var item in basket)
                {
                    _context.shops.Add(item);
                }
                await _context.SaveChangesAsync();

                return basket;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

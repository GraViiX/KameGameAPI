using KameGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Interfaces
{
    public interface IShopRepo
    {
        Task<List<ShopModel>> SavePurchasesRepo(List<ShopModel> basket);
    }
}

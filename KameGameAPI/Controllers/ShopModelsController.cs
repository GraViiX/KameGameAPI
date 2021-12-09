using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KameGameAPI.Database;
using KameGameAPI.Models;
using KameGameAPI.Interfaces;

namespace KameGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopModelsController : ControllerBase
    {
        private readonly IShopService _context;

        public ShopModelsController(IShopService context)
        {
            _context = context;
        }

        [HttpPost("SavePurchases")]
        public async Task<ActionResult<ShopModel>> SavePurchases(List<ShopModel> basket)
        {
            try
            {
                List<ShopModel> shop = await _context.SavePurchasesService(basket);
                if (shop == null)
                {
                    return BadRequest();
                }
                else if (shop.Count == 0)
                {
                    return NoContent();
                }                
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        //private readonly DatabaseContext _context;

        //public ShopModelsController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/ShopModels
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ShopModel>>> Getshops()
        //{
        //    return await _context.shops.ToListAsync();
        //}

        //// GET: api/ShopModels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ShopModel>> GetShopModel(int id)
        //{
        //    var shopModel = await _context.shops.FindAsync(id);

        //    if (shopModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return shopModel;
        //}

        //// PUT: api/ShopModels/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShopModel(int id, ShopModel shopModel)
        //{
        //    if (id != shopModel.ShopId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shopModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShopModelExists(id))
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

        //// POST: api/ShopModels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ShopModel>> PostShopModel(ShopModel shopModel)
        //{
        //    _context.shops.Add(shopModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetShopModel", new { id = shopModel.ShopId }, shopModel);
        //}

        //// DELETE: api/ShopModels/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteShopModel(int id)
        //{
        //    var shopModel = await _context.shops.FindAsync(id);
        //    if (shopModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.shops.Remove(shopModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ShopModelExists(int id)
        //{
        //    return _context.shops.Any(e => e.ShopId == id);
        //}
    }
}

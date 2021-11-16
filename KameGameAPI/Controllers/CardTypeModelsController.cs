using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KameGameAPI.Database;
using KameGameAPI.Models;

namespace KameGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypeModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CardTypeModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CardTypeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardTypeModel>>> GetcardTypes()
        {
            return await _context.cardTypes.ToListAsync();
        }

        // GET: api/CardTypeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardTypeModel>> GetCardTypeModel(int id)
        {
            var cardTypeModel = await _context.cardTypes.FindAsync(id);

            if (cardTypeModel == null)
            {
                return NotFound();
            }

            return cardTypeModel;
        }

        // PUT: api/CardTypeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardTypeModel(int id, CardTypeModel cardTypeModel)
        {
            if (id != cardTypeModel.CardTypeId)
            {
                return BadRequest();
            }

            _context.Entry(cardTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardTypeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CardTypeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardTypeModel>> PostCardTypeModel(CardTypeModel cardTypeModel)
        {
            _context.cardTypes.Add(cardTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardTypeModel", new { id = cardTypeModel.CardTypeId }, cardTypeModel);
        }

        // DELETE: api/CardTypeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardTypeModel(int id)
        {
            var cardTypeModel = await _context.cardTypes.FindAsync(id);
            if (cardTypeModel == null)
            {
                return NotFound();
            }

            _context.cardTypes.Remove(cardTypeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardTypeModelExists(int id)
        {
            return _context.cardTypes.Any(e => e.CardTypeId == id);
        }
    }
}

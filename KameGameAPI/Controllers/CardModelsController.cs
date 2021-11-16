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
    public class CardModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CardModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/CardModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardModel>>> Getcards()
        {
            return await _context.cards.ToListAsync();
        }

        // GET: api/CardModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardModel>> GetCardModel(int id)
        {
            var cardModel = await _context.cards.FindAsync(id);

            if (cardModel == null)
            {
                return NotFound();
            }

            return cardModel;
        }

        // PUT: api/CardModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardModel(int id, CardModel cardModel)
        {
            if (id != cardModel.CardId)
            {
                return BadRequest();
            }

            _context.Entry(cardModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardModelExists(id))
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

        // POST: api/CardModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardModel>> PostCardModel(CardModel cardModel)
        {
            _context.cards.Add(cardModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardModel", new { id = cardModel.CardId }, cardModel);
        }

        // DELETE: api/CardModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardModel(int id)
        {
            var cardModel = await _context.cards.FindAsync(id);
            if (cardModel == null)
            {
                return NotFound();
            }

            _context.cards.Remove(cardModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardModelExists(int id)
        {
            return _context.cards.Any(e => e.CardId == id);
        }
    }
}

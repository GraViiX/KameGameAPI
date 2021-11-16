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
    public class PostcodeModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PostcodeModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PostcodeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostcodeModel>>> Getpostcodes()
        {
            return await _context.postcodes.ToListAsync();
        }

        // GET: api/PostcodeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostcodeModel>> GetPostcodeModel(int id)
        {
            var postcodeModel = await _context.postcodes.FindAsync(id);

            if (postcodeModel == null)
            {
                return NotFound();
            }

            return postcodeModel;
        }

        // PUT: api/PostcodeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostcodeModel(int id, PostcodeModel postcodeModel)
        {
            if (id != postcodeModel.PostcodeId)
            {
                return BadRequest();
            }

            _context.Entry(postcodeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostcodeModelExists(id))
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

        // POST: api/PostcodeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostcodeModel>> PostPostcodeModel(PostcodeModel postcodeModel)
        {
            _context.postcodes.Add(postcodeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostcodeModel", new { id = postcodeModel.PostcodeId }, postcodeModel);
        }

        // DELETE: api/PostcodeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostcodeModel(int id)
        {
            var postcodeModel = await _context.postcodes.FindAsync(id);
            if (postcodeModel == null)
            {
                return NotFound();
            }

            _context.postcodes.Remove(postcodeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostcodeModelExists(int id)
        {
            return _context.postcodes.Any(e => e.PostcodeId == id);
        }
    }
}

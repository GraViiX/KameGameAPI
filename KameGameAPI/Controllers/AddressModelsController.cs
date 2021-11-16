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
    public class AddressModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AddressModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AddressModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressModel>>> Getaddresses()
        {
            return await _context.addresses.ToListAsync();
        }

        // GET: api/AddressModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetAddressModel(int id)
        {
            var addressModel = await _context.addresses.FindAsync(id);

            if (addressModel == null)
            {
                return NotFound();
            }

            return addressModel;
        }

        // PUT: api/AddressModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressModel(int id, AddressModel addressModel)
        {
            if (id != addressModel.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(addressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressModelExists(id))
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

        // POST: api/AddressModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddressModel>> PostAddressModel(AddressModel addressModel)
        {
            _context.addresses.Add(addressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressModel", new { id = addressModel.AddressId }, addressModel);
        }

        // DELETE: api/AddressModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressModel(int id)
        {
            var addressModel = await _context.addresses.FindAsync(id);
            if (addressModel == null)
            {
                return NotFound();
            }

            _context.addresses.Remove(addressModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressModelExists(int id)
        {
            return _context.addresses.Any(e => e.AddressId == id);
        }
    }
}

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
    public class RoleModelsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RoleModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RoleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleModel>>> Getroles()
        {
            return await _context.roles.ToListAsync();
        }

        // GET: api/RoleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleModel>> GetRoleModel(int id)
        {
            var roleModel = await _context.roles.FindAsync(id);

            if (roleModel == null)
            {
                return NotFound();
            }

            return roleModel;
        }

        // PUT: api/RoleModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleModel(int id, RoleModel roleModel)
        {
            if (id != roleModel.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleModelExists(id))
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

        // POST: api/RoleModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleModel>> PostRoleModel(RoleModel roleModel)
        {
            _context.roles.Add(roleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleModel", new { id = roleModel.RoleId }, roleModel);
        }

        // DELETE: api/RoleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleModel(int id)
        {
            var roleModel = await _context.roles.FindAsync(id);
            if (roleModel == null)
            {
                return NotFound();
            }

            _context.roles.Remove(roleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleModelExists(int id)
        {
            return _context.roles.Any(e => e.RoleId == id);
        }
    }
}

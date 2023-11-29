using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCRestitution.Data;
using CCRestitution.Models;

namespace CCRestitution.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimsApiController : ControllerBase
    {
        private readonly DataContext _context;

        public VictimsApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/VictimsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Victim>>> GetVictims()
        {
            return await _context.Victims.ToListAsync();
        }

        // GET: api/VictimsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Victim>> GetVictim(int id)
        {
            var victim = await _context.Victims.FindAsync(id);

            if (victim == null)
            {
                return NotFound();
            }

            return victim;
        }

        // PUT: api/VictimsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVictim(int id, Victim victim)
        {
            if (id != victim.VictimId)
            {
                return BadRequest();
            }

            _context.Entry(victim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VictimExists(id))
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

        // POST: api/VictimsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Victim>> PostVictim(Victim victim)
        {
            _context.Victims.Add(victim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVictim", new { id = victim.VictimId }, victim);
        }

        // DELETE: api/VictimsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVictim(int id)
        {
            var victim = await _context.Victims.FindAsync(id);
            if (victim == null)
            {
                return NotFound();
            }

            _context.Victims.Remove(victim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VictimExists(int id)
        {
            return _context.Victims.Any(e => e.VictimId == id);
        }
    }
}

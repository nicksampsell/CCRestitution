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
    public class DefendantsApiController : ControllerBase
    {
        private readonly DataContext _context;

        public DefendantsApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DefendantsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Defendant>>> GetDefendants()
        {
            return await _context.Defendants.ToListAsync();
        }

        // GET: api/DefendantsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Defendant>> GetDefendant(int id)
        {
            var defendant = await _context.Defendants.FindAsync(id);

            if (defendant == null)
            {
                return NotFound();
            }

            return defendant;
        }

        // PUT: api/DefendantsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefendant(int id, Defendant defendant)
        {
            if (id != defendant.DefendantId)
            {
                return BadRequest();
            }

            _context.Entry(defendant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefendantExists(id))
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

        // POST: api/DefendantsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Defendant>> PostDefendant(Defendant defendant)
        {
            _context.Defendants.Add(defendant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefendant", new { id = defendant.DefendantId }, defendant);
        }

        // DELETE: api/DefendantsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefendant(int id)
        {
            var defendant = await _context.Defendants.FindAsync(id);
            if (defendant == null)
            {
                return NotFound();
            }

            _context.Defendants.Remove(defendant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DefendantExists(int id)
        {
            return _context.Defendants.Any(e => e.DefendantId == id);
        }
    }
}

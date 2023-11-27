using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCRestitution.Data;
using CCRestitution.Models;

namespace CCRestitution.Controllers
{
    public class ArrestingAgenciesController : Controller
    {
        private readonly DataContext _context;

        public ArrestingAgenciesController(DataContext context)
        {
            _context = context;
        }

        // GET: ArrestingAgencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArrestingAgencies.ToListAsync());
        }

        // GET: ArrestingAgencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrestingAgency = await _context.ArrestingAgencies
                .FirstOrDefaultAsync(m => m.ArrestingAgencyId == id);
            if (arrestingAgency == null)
            {
                return NotFound();
            }

            return View(arrestingAgency);
        }

        // GET: ArrestingAgencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArrestingAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArrestingAgencyId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] ArrestingAgency arrestingAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrestingAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrestingAgency);
        }

        // GET: ArrestingAgencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrestingAgency = await _context.ArrestingAgencies.FindAsync(id);
            if (arrestingAgency == null)
            {
                return NotFound();
            }
            return View(arrestingAgency);
        }

        // POST: ArrestingAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArrestingAgencyId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] ArrestingAgency arrestingAgency)
        {
            if (id != arrestingAgency.ArrestingAgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrestingAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrestingAgencyExists(arrestingAgency.ArrestingAgencyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(arrestingAgency);
        }

        // GET: ArrestingAgencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrestingAgency = await _context.ArrestingAgencies
                .FirstOrDefaultAsync(m => m.ArrestingAgencyId == id);
            if (arrestingAgency == null)
            {
                return NotFound();
            }

            return View(arrestingAgency);
        }

        // POST: ArrestingAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrestingAgency = await _context.ArrestingAgencies.FindAsync(id);
            if (arrestingAgency != null)
            {
                _context.ArrestingAgencies.Remove(arrestingAgency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrestingAgencyExists(int id)
        {
            return _context.ArrestingAgencies.Any(e => e.ArrestingAgencyId == id);
        }
    }
}

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
    public class TreatmentAgenciesController : Controller
    {
        private readonly DataContext _context;

        public TreatmentAgenciesController(DataContext context)
        {
            _context = context;
        }

        // GET: TreatmentAgencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TreatmentAgencies.ToListAsync());
        }

        // GET: TreatmentAgencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentAgency = await _context.TreatmentAgencies
                .FirstOrDefaultAsync(m => m.TreatmentAgencyId == id);
            if (treatmentAgency == null)
            {
                return NotFound();
            }

            return View(treatmentAgency);
        }

        // GET: TreatmentAgencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreatmentAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreatmentAgencyId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] TreatmentAgency treatmentAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentAgency);
        }

        // GET: TreatmentAgencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentAgency = await _context.TreatmentAgencies.FindAsync(id);
            if (treatmentAgency == null)
            {
                return NotFound();
            }
            return View(treatmentAgency);
        }

        // POST: TreatmentAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreatmentAgencyId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] TreatmentAgency treatmentAgency)
        {
            if (id != treatmentAgency.TreatmentAgencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentAgencyExists(treatmentAgency.TreatmentAgencyId))
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
            return View(treatmentAgency);
        }

        // GET: TreatmentAgencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentAgency = await _context.TreatmentAgencies
                .FirstOrDefaultAsync(m => m.TreatmentAgencyId == id);
            if (treatmentAgency == null)
            {
                return NotFound();
            }

            return View(treatmentAgency);
        }

        // POST: TreatmentAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentAgency = await _context.TreatmentAgencies.FindAsync(id);
            if (treatmentAgency != null)
            {
                _context.TreatmentAgencies.Remove(treatmentAgency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentAgencyExists(int id)
        {
            return _context.TreatmentAgencies.Any(e => e.TreatmentAgencyId == id);
        }
    }
}

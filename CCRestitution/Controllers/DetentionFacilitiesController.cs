using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCRestitution.Data;
using CCRestitution.Models;
using Pagination.EntityFrameworkCore.Extensions;

namespace CCRestitution.Controllers
{
    public class DetentionFacilitiesController : Controller
    {
        private readonly DataContext _context;

        public DetentionFacilitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: DetentionFacilities
        public async Task<IActionResult> Index(string search = "", int page = 1, int perPage = 100)
        {
            var query = _context.DetentionFacilities.AsQueryable();

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Contains(search) || x.Address.Contains(search) || x.Address2.Contains(search) || x.City.Contains(search) || x.State.Contains(search) || x.ZipCode.Contains(search) || x.Phone.Contains(search) || x.Fax.Contains(search));
            }
            ViewBag.PerPage = perPage;
            ViewBag.Search = search;

            return View(new Pagination<DetentionFacility>(await query.Skip((page - 1) * perPage).Take(perPage).ToListAsync(), await query.CountAsync(), page, perPage));
        }

        // GET: DetentionFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detentionFacility = await _context.DetentionFacilities
                .FirstOrDefaultAsync(m => m.DetentionFacilityId == id);
            if (detentionFacility == null)
            {
                return NotFound();
            }

            return View(detentionFacility);
        }

        // GET: DetentionFacilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetentionFacilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetentionFacilityId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] DetentionFacility detentionFacility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detentionFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detentionFacility);
        }

        // GET: DetentionFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detentionFacility = await _context.DetentionFacilities.FindAsync(id);
            if (detentionFacility == null)
            {
                return NotFound();
            }
            return View(detentionFacility);
        }

        // POST: DetentionFacilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetentionFacilityId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] DetentionFacility detentionFacility)
        {
            if (id != detentionFacility.DetentionFacilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detentionFacility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetentionFacilityExists(detentionFacility.DetentionFacilityId))
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
            return View(detentionFacility);
        }

        // GET: DetentionFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detentionFacility = await _context.DetentionFacilities
                .FirstOrDefaultAsync(m => m.DetentionFacilityId == id);
            if (detentionFacility == null)
            {
                return NotFound();
            }

            return View(detentionFacility);
        }

        // POST: DetentionFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detentionFacility = await _context.DetentionFacilities.FindAsync(id);
            if (detentionFacility != null)
            {
                _context.DetentionFacilities.Remove(detentionFacility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetentionFacilityExists(int id)
        {
            return _context.DetentionFacilities.Any(e => e.DetentionFacilityId == id);
        }
    }
}

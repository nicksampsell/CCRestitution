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
    public class CourtsController : Controller
    {
        private readonly DataContext _context;

        public CourtsController(DataContext context)
        {
            _context = context;
        }

        // GET: Courts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courts.ToListAsync());
        }

        // GET: Courts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .FirstOrDefaultAsync(m => m.CourtId == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // GET: Courts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourtId,Title,Address,Address2,City,State,ZipCode,Phone,Fax,Created,Updated")] Court court)
        {
            if (ModelState.IsValid)
            {
                _context.Add(court);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(court);
        }

        // GET: Courts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts.FindAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            return View(court);
        }

        // POST: Courts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourtId,Title,Address,Address2,City,State,ZipCode,Phone,Fax,Created,Updated")] Court court)
        {
            if (id != court.CourtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(court);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourtExists(court.CourtId))
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
            return View(court);
        }

        // GET: Courts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .FirstOrDefaultAsync(m => m.CourtId == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // POST: Courts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var court = await _context.Courts.FindAsync(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourtExists(int id)
        {
            return _context.Courts.Any(e => e.CourtId == id);
        }
    }
}

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
    public class JudgesController : Controller
    {
        private readonly DataContext _context;

        public JudgesController(DataContext context)
        {
            _context = context;
        }

        // GET: Judges
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Judges.Include(j => j.Court);
            return View(await dataContext.ToListAsync());
        }

        // GET: Judges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judges
                .Include(j => j.Court)
                .FirstOrDefaultAsync(m => m.JudgeId == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // GET: Judges/Create
        public IActionResult Create()
        {
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId");
            return View();
        }

        // POST: Judges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JudgeId,FirstName,LastName,CourtId,Created,Updated")] Judge judge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(judge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", judge.CourtId);
            return View(judge);
        }

        // GET: Judges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judges.FindAsync(id);
            if (judge == null)
            {
                return NotFound();
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", judge.CourtId);
            return View(judge);
        }

        // POST: Judges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JudgeId,FirstName,LastName,CourtId,Created,Updated")] Judge judge)
        {
            if (id != judge.JudgeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(judge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JudgeExists(judge.JudgeId))
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
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", judge.CourtId);
            return View(judge);
        }

        // GET: Judges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judge = await _context.Judges
                .Include(j => j.Court)
                .FirstOrDefaultAsync(m => m.JudgeId == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // POST: Judges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var judge = await _context.Judges.FindAsync(id);
            if (judge != null)
            {
                _context.Judges.Remove(judge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JudgeExists(int id)
        {
            return _context.Judges.Any(e => e.JudgeId == id);
        }
    }
}

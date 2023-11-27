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
    public class DefendantsController : Controller
    {
        private readonly DataContext _context;

        public DefendantsController(DataContext context)
        {
            _context = context;
        }

        // GET: Defendants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Defendants.ToListAsync());
        }

        // GET: Defendants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defendant = await _context.Defendants
                .FirstOrDefaultAsync(m => m.DefendantId == id);
            if (defendant == null)
            {
                return NotFound();
            }

            return View(defendant);
        }

        // GET: Defendants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Defendants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DefendantId,FirstName,MiddleName,LastName,Suffix,SSN,DOB,Sex,Address1,Address2,City,State,ZipCode,Created,Updated")] Defendant defendant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defendant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defendant);
        }

        // GET: Defendants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defendant = await _context.Defendants.FindAsync(id);
            if (defendant == null)
            {
                return NotFound();
            }
            return View(defendant);
        }

        // POST: Defendants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DefendantId,FirstName,MiddleName,LastName,Suffix,SSN,DOB,Sex,Address1,Address2,City,State,ZipCode,Created,Updated")] Defendant defendant)
        {
            if (id != defendant.DefendantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defendant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefendantExists(defendant.DefendantId))
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
            return View(defendant);
        }

        // GET: Defendants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defendant = await _context.Defendants
                .FirstOrDefaultAsync(m => m.DefendantId == id);
            if (defendant == null)
            {
                return NotFound();
            }

            return View(defendant);
        }

        // POST: Defendants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var defendant = await _context.Defendants.FindAsync(id);
            if (defendant != null)
            {
                _context.Defendants.Remove(defendant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefendantExists(int id)
        {
            return _context.Defendants.Any(e => e.DefendantId == id);
        }
    }
}

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

namespace CCRestitution.Area.Accounts.Controllers
{
    [Area("Accounts")]
    public class VictimsController : Controller
    {
        private readonly DataContext _context;

        public VictimsController(DataContext context)
        {
            _context = context;
        }

        // GET: Victims
        public async Task<IActionResult> Index(string search = "", string? fName = null, string? lname = null, int page = 1, int perPage = 100)
        {
            var victims = _context.Victims.Include(x => x.PriorResidences).Include(x => x.Accounts).AsQueryable();

            if (search != null)
            {
                victims = victims.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Address.Contains(search) || x.Address2.Contains(search) || x.City.Contains(search) || x.State.Contains(search) || x.ZipCode.Contains(search) || x.PriorResidences.Any(y => y.Address.Contains(search) || y.Address2.Contains(search) || y.City.Contains(search) || y.State.Contains(search) || y.ZipCode.Contains(search)) || x.Accounts.Any(y => y.Docket.Contains(search)));
            }

            if (fName != null)
            {
                victims = victims.Where(x => x.FirstName.Contains(fName));
            }

            if (lname != null)
            {
                victims = victims.Where(x => x.LastName.Contains(lname));
            }

            ViewBag.PerPage = perPage;
            ViewBag.Search = search;
            ViewBag.FName = fName;
            ViewBag.LName = lname;
            return View(new Pagination<Victim>(await victims.Skip((page - 1) * perPage).Take(perPage).ToListAsync(), await victims.CountAsync(), page, perPage));
        }

        // GET: Victims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims
                .FirstOrDefaultAsync(m => m.VictimId == id);
            if (victim == null)
            {
                return NotFound();
            }

            return View(victim);
        }

        // GET: Victims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Victims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VictimId,CaseNumber,FirstName,MiddleName,LastName,Address,Address2,City,ZipCode,Type,AmountDue,AmountPaid,Notes,Created,Updated")] Victim victim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(victim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(victim);
        }

        // GET: Victims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims.FindAsync(id);
            if (victim == null)
            {
                return NotFound();
            }
            return View(victim);
        }

        // POST: Victims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VictimId,CaseNumber,FirstName,MiddleName,LastName,Address,Address2,City,ZipCode,Type,AmountDue,AmountPaid,Notes,Created,Updated")] Victim victim)
        {
            if (id != victim.VictimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(victim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VictimExists(victim.VictimId))
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
            return View(victim);
        }

        // GET: Victims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims
                .FirstOrDefaultAsync(m => m.VictimId == id);
            if (victim == null)
            {
                return NotFound();
            }

            return View(victim);
        }

        // POST: Victims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var victim = await _context.Victims.FindAsync(id);
            if (victim != null)
            {
                _context.Victims.Remove(victim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VictimExists(int id)
        {
            return _context.Victims.Any(e => e.VictimId == id);
        }
    }
}

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

namespace CCRestitution.Area.Admin.Controllers
{
    [Area("Admin")]
    public class ProbationOfficersController : Controller
    {
        private readonly DataContext _context;

        public ProbationOfficersController(DataContext context)
        {
            _context = context;
        }

        // GET: ProbationOfficers
        public async Task<IActionResult> Index(string search = "", int page = 1, int perPage = 100, string sortBy = "id", string order = "asc")
        {
            var query = _context.ProbationOfficers.AsQueryable();
            bool orderByDescending = order.ToLower() == "desc" ? true : false;
            sortBy = sortBy == "id" ? "ProbationOfficerId" : sortBy;
            ViewBag.PerPage = perPage;
            ViewBag.Search = search;

            if (!string.IsNullOrEmpty(search))
            {
                //query = query.Where()... search here
            }

            return View(await query.AsPaginationAsync(page, perPage, sortColumn: sortBy, orderByDescending: orderByDescending));
        }

        // GET: ProbationOfficers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficer = await _context.ProbationOfficers
                .Include(p => p.ProbationDepartment)
                .FirstOrDefaultAsync(m => m.ProbationOfficerId == id);
            if (probationOfficer == null)
            {
                return NotFound();
            }

            return View(probationOfficer);
        }

        // GET: ProbationOfficers/Create
        public IActionResult Create()
        {
            ViewData["ProbationDepartmentId"] = new SelectList(_context.ProbationDepartments, "ProbationDepartmentId", "ProbationDepartmentId");
            return View();
        }

        // POST: ProbationOfficers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProbationOfficerId,FirstName,MiddleName,LastName,Position,Email,ProbationDepartmentId")] ProbationOfficer probationOfficer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probationOfficer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProbationDepartmentId"] = new SelectList(_context.ProbationDepartments, "ProbationDepartmentId", "ProbationDepartmentId", probationOfficer.ProbationDepartmentId);
            return View(probationOfficer);
        }

        // GET: ProbationOfficers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficer = await _context.ProbationOfficers.FindAsync(id);
            if (probationOfficer == null)
            {
                return NotFound();
            }
            ViewData["ProbationDepartmentId"] = new SelectList(_context.ProbationDepartments, "ProbationDepartmentId", "ProbationDepartmentId", probationOfficer.ProbationDepartmentId);
            return View(probationOfficer);
        }

        // POST: ProbationOfficers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProbationOfficerId,FirstName,MiddleName,LastName,Position,Email,ProbationDepartmentId")] ProbationOfficer probationOfficer)
        {
            if (id != probationOfficer.ProbationOfficerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probationOfficer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbationOfficerExists(probationOfficer.ProbationOfficerId))
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
            ViewData["ProbationDepartmentId"] = new SelectList(_context.ProbationDepartments, "ProbationDepartmentId", "ProbationDepartmentId", probationOfficer.ProbationDepartmentId);
            return View(probationOfficer);
        }

        // GET: ProbationOfficers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationOfficer = await _context.ProbationOfficers
                .Include(p => p.ProbationDepartment)
                .FirstOrDefaultAsync(m => m.ProbationOfficerId == id);
            if (probationOfficer == null)
            {
                return NotFound();
            }

            return View(probationOfficer);
        }

        // POST: ProbationOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probationOfficer = await _context.ProbationOfficers.FindAsync(id);
            if (probationOfficer != null)
            {
                _context.ProbationOfficers.Remove(probationOfficer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbationOfficerExists(int id)
        {
            return _context.ProbationOfficers.Any(e => e.ProbationOfficerId == id);
        }
    }
}

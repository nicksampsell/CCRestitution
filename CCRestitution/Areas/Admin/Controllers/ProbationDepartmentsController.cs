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
    public class ProbationDepartmentsController : Controller
    {
        private readonly DataContext _context;

        public ProbationDepartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: ProbationDepartments
        public async Task<IActionResult> Index(string search = "", int page = 1, int perPage = 100, string sortBy = "id", string order = "asc")
        {
            var query = _context.ProbationDepartments.AsQueryable();
            bool orderByDescending = order.ToLower() == "desc" ? true : false;
            sortBy = sortBy == "id" ? "ProbationDepartmentId" : sortBy;
            ViewBag.PerPage = perPage;
            ViewBag.Search = search;

            if (!string.IsNullOrEmpty(search))
            {
                //query = query.Where()... search here
            }

            return View(await query.AsPaginationAsync(page, perPage, sortColumn: sortBy, orderByDescending: orderByDescending));
        }

        // GET: ProbationDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationDepartment = await _context.ProbationDepartments
                .FirstOrDefaultAsync(m => m.ProbationDepartmentId == id);
            if (probationDepartment == null)
            {
                return NotFound();
            }

            return View(probationDepartment);
        }

        // GET: ProbationDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProbationDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProbationDepartmentId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] ProbationDepartment probationDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(probationDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(probationDepartment);
        }

        // GET: ProbationDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationDepartment = await _context.ProbationDepartments.FindAsync(id);
            if (probationDepartment == null)
            {
                return NotFound();
            }
            return View(probationDepartment);
        }

        // POST: ProbationDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProbationDepartmentId,Title,Address,Address2,City,State,ZipCode,Phone,Fax")] ProbationDepartment probationDepartment)
        {
            if (id != probationDepartment.ProbationDepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(probationDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProbationDepartmentExists(probationDepartment.ProbationDepartmentId))
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
            return View(probationDepartment);
        }

        // GET: ProbationDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var probationDepartment = await _context.ProbationDepartments
                .FirstOrDefaultAsync(m => m.ProbationDepartmentId == id);
            if (probationDepartment == null)
            {
                return NotFound();
            }

            return View(probationDepartment);
        }

        // POST: ProbationDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var probationDepartment = await _context.ProbationDepartments.FindAsync(id);
            if (probationDepartment != null)
            {
                _context.ProbationDepartments.Remove(probationDepartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProbationDepartmentExists(int id)
        {
            return _context.ProbationDepartments.Any(e => e.ProbationDepartmentId == id);
        }
    }
}

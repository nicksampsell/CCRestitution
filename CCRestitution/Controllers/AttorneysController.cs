﻿using System;
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
    public class AttorneysController : Controller
    {
        private readonly DataContext _context;

        public AttorneysController(DataContext context)
        {
            _context = context;
        }

        // GET: Attorneys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attorneys.ToListAsync());
        }

        // GET: Attorneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys
                .FirstOrDefaultAsync(m => m.AttorneyId == id);
            if (attorney == null)
            {
                return NotFound();
            }

            return View(attorney);
        }

        // GET: Attorneys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attorneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttorneyId,FirstName,MiddleName,LastName,Address,Address2,City,State,ZipCode,Email,Phone,Fax")] Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attorney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attorney);
        }

        // GET: Attorneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys.FindAsync(id);
            if (attorney == null)
            {
                return NotFound();
            }
            return View(attorney);
        }

        // POST: Attorneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttorneyId,FirstName,MiddleName,LastName,Address,Address2,City,State,ZipCode,Email,Phone,Fax")] Attorney attorney)
        {
            if (id != attorney.AttorneyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attorney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttorneyExists(attorney.AttorneyId))
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
            return View(attorney);
        }

        // GET: Attorneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys
                .FirstOrDefaultAsync(m => m.AttorneyId == id);
            if (attorney == null)
            {
                return NotFound();
            }

            return View(attorney);
        }

        // POST: Attorneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attorney = await _context.Attorneys.FindAsync(id);
            if (attorney != null)
            {
                _context.Attorneys.Remove(attorney);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttorneyExists(int id)
        {
            return _context.Attorneys.Any(e => e.AttorneyId == id);
        }
    }
}
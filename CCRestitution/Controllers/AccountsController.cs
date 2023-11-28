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
    public class AccountsController : Controller
    {
        private readonly DataContext _context;

        public AccountsController(DataContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index(string search = "", string? docket = null, string? fname = null, string? lname = null, int page = 1, int perPage = 100)
        {
            var query = _context.Accounts.AsSplitQuery().Include(a => a.Court).Include(a => a.Judge).Include(x => x.Defendants).Include(x => x.Victims.OrderBy(x => x.AmountDue)).AsQueryable();

            if (search != null)
            {
                query = query.Where(x => x.Docket.Contains(search) || x.Judge.FirstName.Contains(search) || x.Judge.LastName.Contains(search) || x.Court.Title.Contains(search));
            }


            if (docket != null)
            {
                query = query.Where(x => x.Docket.Contains(docket));
            }

            if (fname != null)
            {
                query = query.Where(x => x.Defendants.Any(y => y.FirstName.Contains(fname)));
            }

            if (lname != null)
            {
                query = query.Where(x => x.Defendants.Any(y => y.LastName.Contains(lname)));
            }

            query = query.OrderByDescending(x => x.AssignedDate);
            ViewBag.PerPage = perPage;
            ViewBag.Docket = docket;
            ViewBag.FName = fname;
            ViewBag.LName = lname;

            return View(new Pagination<Account>(await query.Skip((page - 1) * perPage).Take(perPage).ToListAsync(), await query.CountAsync(), page, perPage));
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Court)
                .Include(a => a.Judge)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId");
            ViewData["JudgeId"] = new SelectList(_context.Judges, "JudgeId", "JudgeId");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,CaseNumber,Docket,Type,AssignedDate,ClosedDate,ArrestDate,AgencyCode,CustodyStatus,CourtId,JudgeId,Created,Updated")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", account.CourtId);
            ViewData["JudgeId"] = new SelectList(_context.Judges, "JudgeId", "JudgeId", account.JudgeId);
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", account.CourtId);
            ViewData["JudgeId"] = new SelectList(_context.Judges, "JudgeId", "JudgeId", account.JudgeId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,CaseNumber,Docket,Type,AssignedDate,ClosedDate,ArrestDate,AgencyCode,CustodyStatus,CourtId,JudgeId,Created,Updated")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
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
            ViewData["CourtId"] = new SelectList(_context.Courts, "CourtId", "CourtId", account.CourtId);
            ViewData["JudgeId"] = new SelectList(_context.Judges, "JudgeId", "JudgeId", account.JudgeId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Court)
                .Include(a => a.Judge)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}

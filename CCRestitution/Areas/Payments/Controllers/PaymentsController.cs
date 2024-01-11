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

namespace CCRestitution.Area.Payments.Controllers
{
    [Area("Payments")]
    public class PaymentsController : Controller
    {
        private readonly DataContext _context;

        public PaymentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index(string search = "", int page = 1, int perPage = 100, string sortBy = "id", string order = "desc")
        {
            var query = _context.Payments.Include(x => x.Account).Include(x => x.User).AsQueryable();
            bool orderByDescending = order.ToLower() == "desc" ? true : false;
            sortBy = sortBy == "id" ? "PaymentId" : sortBy;
            ViewBag.PerPage = perPage;
            ViewBag.Search = search;

            if (!string.IsNullOrEmpty(search))
            {
                //query = query.Where()... search here
            }

            return View(await query.AsPaginationAsync(page, perPage, sortColumn: sortBy, orderByDescending: orderByDescending));
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,UserId,AccountId, DefendantId,DatePaid,FineAmount,MandatorySurchargeAmount,EHMAmount,RestitutionAmount,SurchargeAmount,OtherAmount,SupervisionFee,Notes,PaymentMethod,TotalAmount,Created,Updated")] Payment payment)
        {
            payment.UserId = int.Parse(User.FindFirst("UserId").Value ?? "");
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,UserId,AccountId, DefendantId,DatePaid,FineAmount,MandatorySurchargeAmount,EHMAmount,RestitutionAmount,SurchargeAmount,OtherAmount,SupervisionFee,Notes,PaymentMethod,TotalAmount,Updated")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
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
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}

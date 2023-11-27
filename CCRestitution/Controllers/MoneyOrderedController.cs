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
    public class MoneyOrderedController : Controller
    {
        private readonly DataContext _context;

        public MoneyOrderedController(DataContext context)
        {
            _context = context;
        }

        // GET: MoneyOrdereds
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoneyOrdered.ToListAsync());
        }

        // GET: MoneyOrdereds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyOrdered = await _context.MoneyOrdered
                .FirstOrDefaultAsync(m => m.MoneyOrderedId == id);
            if (moneyOrdered == null)
            {
                return NotFound();
            }

            return View(moneyOrdered);
        }

        // GET: MoneyOrdereds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoneyOrdereds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoneyOrderedId,AccountNumber,Opened,Closed,EHM,FineAmount,FineOpenDate,FinePayByDate,FineCloseDate,MandatorySurchargeAmount,MandatorySurchargeOpenDate,MandatorySurchargePayByDate,MandatorySurchargeCloseDate,EHMAmount,RestitutionAmount,RestitutionOpenDate,RestitutionPayByDate,RestitutionCloseDate,OtherAmount,OtherOpenDate,OtherPayByDate,OtherCloseDate,SurchargeAmount,SurchargeOpenDate,SurchargePayByDate,SurchargeCloseDate,SupervisionFeeAmount,SupervisionFeeOpenDate,SupervisionFeeCloseDate,YO,Notes,Created,Updated")] MoneyOrdered moneyOrdered)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyOrdered);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneyOrdered);
        }

        // GET: MoneyOrdereds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyOrdered = await _context.MoneyOrdered.FindAsync(id);
            if (moneyOrdered == null)
            {
                return NotFound();
            }
            return View(moneyOrdered);
        }

        // POST: MoneyOrdereds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoneyOrderedId,AccountNumber,Opened,Closed,EHM,FineAmount,FineOpenDate,FinePayByDate,FineCloseDate,MandatorySurchargeAmount,MandatorySurchargeOpenDate,MandatorySurchargePayByDate,MandatorySurchargeCloseDate,EHMAmount,RestitutionAmount,RestitutionOpenDate,RestitutionPayByDate,RestitutionCloseDate,OtherAmount,OtherOpenDate,OtherPayByDate,OtherCloseDate,SurchargeAmount,SurchargeOpenDate,SurchargePayByDate,SurchargeCloseDate,SupervisionFeeAmount,SupervisionFeeOpenDate,SupervisionFeeCloseDate,YO,Notes,Created,Updated")] MoneyOrdered moneyOrdered)
        {
            if (id != moneyOrdered.MoneyOrderedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyOrdered);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyOrderedExists(moneyOrdered.MoneyOrderedId))
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
            return View(moneyOrdered);
        }

        // GET: MoneyOrdereds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyOrdered = await _context.MoneyOrdered
                .FirstOrDefaultAsync(m => m.MoneyOrderedId == id);
            if (moneyOrdered == null)
            {
                return NotFound();
            }

            return View(moneyOrdered);
        }

        // POST: MoneyOrdereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyOrdered = await _context.MoneyOrdered.FindAsync(id);
            if (moneyOrdered != null)
            {
                _context.MoneyOrdered.Remove(moneyOrdered);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyOrderedExists(int id)
        {
            return _context.MoneyOrdered.Any(e => e.MoneyOrderedId == id);
        }
    }
}

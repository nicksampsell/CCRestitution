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
    public class CrimesController : Controller
    {
        private readonly DataContext _context;

        public CrimesController(DataContext context)
        {
            _context = context;
        }

        // GET: Crimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Crimes.ToListAsync());
        }

        // GET: Crimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime = await _context.Crimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crime == null)
            {
                return NotFound();
            }

            return View(crime);
        }

        // GET: Crimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Law_Ordinal,Attempted_Class,Attempted_VF_Indicator,Attempted_NYS_Law_Category,Bus_Driver_Charge_Code,Sex_Offender_Registry_Code,NCIC_Code,UCR_Code,SAFIS_Crime_Cateory_Code,Offense_Category,JO_Indicator,JD_Indicator,IBR_Code,Maxi_Law_Description,Law_Description,Mini_Law_Description,Title,Section,Section13,Sub_Section,Sub_Section13,Degree,EFFECTIVE_DATE,REPEAL_DATE,FP_Offense,Unconst_Date,Weapon_Charge,Armed_VFO_Charge,Minors_Charge,Career_Criminal_Charge,INS_Charge,Non_Seal_Charge,Sub_Convict_Charge,Jail_Charge,Post_Convict_Charge,Auto_Strip_Charge,Full_Law_Description,NYS_Law_Category,VF_Indicator,Class,DNA_Indicator,Attempted_DNA_Indicator,Escape_Charge,Hate_Crime,Date_Invalidated,Terrorism_Indicator,DMV_VTCode,AO_Indicator,RTA_FP_Offense,MODIFIED_DATE,Civil_Confinement_Indicator,Attempted_CCI,Expanded_Law_Literal,Sexually_Motivated_Ind,MCDV_Charge_Indicator,RDLR_Indicator,Created,Updated")] Crime crime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crime);
        }

        // GET: Crimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime = await _context.Crimes.FindAsync(id);
            if (crime == null)
            {
                return NotFound();
            }
            return View(crime);
        }

        // POST: Crimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Law_Ordinal,Attempted_Class,Attempted_VF_Indicator,Attempted_NYS_Law_Category,Bus_Driver_Charge_Code,Sex_Offender_Registry_Code,NCIC_Code,UCR_Code,SAFIS_Crime_Cateory_Code,Offense_Category,JO_Indicator,JD_Indicator,IBR_Code,Maxi_Law_Description,Law_Description,Mini_Law_Description,Title,Section,Section13,Sub_Section,Sub_Section13,Degree,EFFECTIVE_DATE,REPEAL_DATE,FP_Offense,Unconst_Date,Weapon_Charge,Armed_VFO_Charge,Minors_Charge,Career_Criminal_Charge,INS_Charge,Non_Seal_Charge,Sub_Convict_Charge,Jail_Charge,Post_Convict_Charge,Auto_Strip_Charge,Full_Law_Description,NYS_Law_Category,VF_Indicator,Class,DNA_Indicator,Attempted_DNA_Indicator,Escape_Charge,Hate_Crime,Date_Invalidated,Terrorism_Indicator,DMV_VTCode,AO_Indicator,RTA_FP_Offense,MODIFIED_DATE,Civil_Confinement_Indicator,Attempted_CCI,Expanded_Law_Literal,Sexually_Motivated_Ind,MCDV_Charge_Indicator,RDLR_Indicator,Created,Updated")] Crime crime)
        {
            if (id != crime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrimeExists(crime.Id))
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
            return View(crime);
        }

        // GET: Crimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crime = await _context.Crimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crime == null)
            {
                return NotFound();
            }

            return View(crime);
        }

        // POST: Crimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crime = await _context.Crimes.FindAsync(id);
            if (crime != null)
            {
                _context.Crimes.Remove(crime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrimeExists(int id)
        {
            return _context.Crimes.Any(e => e.Id == id);
        }
    }
}

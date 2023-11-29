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
    public class DefendantsController : Controller
    {
        private readonly DataContext _context;

        public DefendantsController(DataContext context)
        {
            _context = context;
        }

        // GET: Defendants
        public async Task<IActionResult> Index(string search = "", string? fName = null, string? lname = null, int page = 1, int perPage = 100)
        {
            var defendants = _context.Defendants.Include(x => x.PriorResidences).Include(x => x.Accounts).AsQueryable();

            if (search != null)
            {
                defendants = defendants.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Address1.Contains(search) || x.Address2.Contains(search) || x.City.Contains(search) || x.State.Contains(search) || x.ZipCode.Contains(search) || x.PriorResidences.Any(y => y.Address.Contains(search) || y.Address2.Contains(search) || y.City.Contains(search) || y.State.Contains(search) || y.ZipCode.Contains(search)) || x.Accounts.Any(y => y.Docket.Contains(search)));
            }

            if (fName != null)
            {
                defendants = defendants.Where(x => x.FirstName.Contains(fName));
            }

            if (lname != null)
            {
                defendants = defendants.Where(x => x.LastName.Contains(lname));
            }

            ViewBag.PerPage = perPage;
            ViewBag.Search = search;
            ViewBag.FName = fName;
            ViewBag.LName = lname;
            return View(new Pagination<Defendant>(await defendants.Skip((page - 1) * perPage).Take(perPage).ToListAsync(), await defendants.CountAsync(), page, perPage));
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
        public async Task<IActionResult> Create([Bind("DefendantId,FirstName,MiddleName,LastName,Suffix,SSN,DOB,Sex,Address1,Address2,City,State,ZipCode,LegacyCaseNumber,NYSID,FBI,Race,HeightFt,HeightIn,Weight,EyeColor,HairColor,IdentifyingMarks,Citizenship,Birthplace,EthnicityOrigin,HIV,Notes,AltPhone,Phone,MaritalStatus,ICEStatus,CellPhone,MaidenName,DriverLicense,DriverLicenseClientId,AlertMessage,PictureLink,RegisteredSexOffenderLevel,RegisteredSexOffenderDate,PhoneOtherName,MilitaryStatus,Employable,EducationLevel,Created,Updated")] Defendant defendant)
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
        public async Task<IActionResult> Edit(int id, [Bind("DefendantId,FirstName,MiddleName,LastName,Suffix,SSN,DOB,Sex,Address1,Address2,City,State,ZipCode,LegacyCaseNumber,NYSID,FBI,Race,HeightFt,HeightIn,Weight,EyeColor,HairColor,IdentifyingMarks,Citizenship,Birthplace,EthnicityOrigin,HIV,Notes,AltPhone,Phone,MaritalStatus,ICEStatus,CellPhone,MaidenName,DriverLicense,DriverLicenseClientId,AlertMessage,PictureLink,RegisteredSexOffenderLevel,RegisteredSexOffenderDate,PhoneOtherName,MilitaryStatus,Employable,EducationLevel,Created,Updated")] Defendant defendant)
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

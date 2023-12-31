﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CCRestitution.Data;
using CCRestitution.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Runtime.Versioning;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace CCRestitution.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Identity,FirstName,LastName,Email,Role,Created,Updated")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Identity,FirstName,LastName,Email,Role,Created,Updated")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [SupportedOSPlatform("windows")]
        [HttpGet("/Users/AD/Filter/{search?}")]
        public async Task<IActionResult> FilterAdUsers(string search)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(search))
            {
                results.Add("results", "");
            }

            List<AD_User> ad_users = new List<AD_User>();
            using (DirectorySearcher searcher = new DirectorySearcher(new DirectoryEntry("LDAP://GOVNET")))
            {
                // Create a search filter that checks for a match in ANY of the specified columns
                string searchFilter = "(&(|(displayName=*" + search + "*)(givenName=*" + search + "*)(sn=*" + search + "*)(mail=*" + search + "*)(userPrincipalName=*" + search + "*)(sAMAccountName=*" + search + "*))(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";

                searcher.Filter = searchFilter;

                foreach (SearchResult result in searcher.FindAll())
                {
                    DirectoryEntry de = result.GetDirectoryEntry();
                    ad_users.Add(new AD_User
                    {
                        FirstName = de.Properties["givenName"].Value?.ToString(),
                        LastName = de.Properties["sn"].Value?.ToString(),
                        Email = de.Properties["mail"].Value?.ToString(),
                        PrincipalName = de.Properties["userPrincipalName"].Value?.ToString(),
                        LoginName = "GOVNET\\" + de.Properties["sAMAccountName"].Value?.ToString(),
                        Username = de.Properties["sAMAccountName"].Value?.ToString()
                    });
                }
            }

            results.Add("results", ad_users);
            return Json(results);
        }

        private void LogAccountInfo(UserPrincipal user)
        {
            DirectoryEntry de = (DirectoryEntry)user.GetUnderlyingObject();
            string accountName = de.Properties["samAccountName"].Value?.ToString();
            string userAccountControl = de.Properties["userAccountControl"].Value?.ToString();
            bool isActive = IsAccountActive(user);
            Console.WriteLine($"Account Name: {accountName}, User Account Control: {userAccountControl}, Active: {isActive}");
        }

        private bool IsAccountActive(UserPrincipal user)
        {
            DirectoryEntry de = (DirectoryEntry)user.GetUnderlyingObject();
            int userAccountControl = (int)de.Properties["userAccountControl"].Value;
            const int disabledFlag = 0x0002; // UserAccountControl flag for disabled accounts

            return (userAccountControl & disabledFlag) != disabledFlag;
        }

        //public async Task<IActionResult> FilterAdUsers(string search)
        //{
        //    Dictionary<string, object> results = new Dictionary<string, object>();

        //    if (string.IsNullOrEmpty(search))
        //    {
        //        results.Add("results", "");
        //    }

        //    List<AD_User> ad_users = new List<AD_User>();
        //    using (var adContext = new PrincipalContext(ContextType.Domain, "GOVNET"))
        //    {
        //        var up = new UserPrincipal(adContext);
        //        using (var searcher = new PrincipalSearcher(up))
        //        {

        //            up.DisplayName = $"*{search}*";
        //            searcher.QueryFilter = up;
        //            foreach (var result in searcher.FindAll())
        //            {
        //                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
        //                ad_users.Add(new AD_User
        //                {
        //                    FirstName = de.Properties["givenName"].Value?.ToString(),
        //                    LastName = de.Properties["sn"].Value?.ToString(),
        //                    Email = de.Properties["mail"].Value?.ToString(),
        //                    PrincipalName = de.Properties["userPrincipalName"].Value?.ToString(),
        //                    LoginName = $"GOVNET\\{de.Properties["samAccountName"].Value?.ToString()}",
        //                    Username = de.Properties["samAccountName"].Value?.ToString()
        //                });
        //            }
        //        }
        //    }
        //    results.Add("results", ad_users);
        //    return Ok(results);
        //}


        [SupportedOSPlatform("windows")]
        private async Task<List<AD_User>> GetADUsers()
        {
            List<AD_User> ad_users = new List<AD_User>();

            using (var adContext = new PrincipalContext(ContextType.Domain, "GOVNET"))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(adContext)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        ad_users.Add(new AD_User
                        {
                            FirstName = de.Properties["givenName"].Value?.ToString(),
                            LastName = de.Properties["sn"].Value?.ToString(),
                            Email = de.Properties["mail"].Value?.ToString(),
                            PrincipalName = de.Properties["userPrincipalName"].Value?.ToString(),
                            LoginName = $"GOVNET\\{de.Properties["samAccountName"].Value?.ToString()}",
                            Username = de.Properties["samAccountName"].Value?.ToString()
                        }); ;
                    }
                }
            }

            return ad_users;
        }

        private void AdUsersAsSelectList(List<AD_User> adUsers)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (AD_User adUser in adUsers)
            {
                items.Add(new SelectListItem($"{adUser.FirstName} {adUser.LastName}", adUser.Username));
            }

            ViewData["AdUsers"] = items;
        }


        public struct AD_User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string PrincipalName { get; set; }
            public string LoginName { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Linq;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    //[Authorize(Roles = "Veteran")]
    //[Authorize(Roles = "Education Rep.")]
    //[Authorize(Roles = "VSO")]
    //[Authorize(Roles ="Employer")]
    public class VeteransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeteransController(ApplicationDbContext context)
        {
           
            
            _context = context;
        }

        // GET: Veterans
        public async Task<IActionResult> Index(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var cust = _context.Veteran.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            //if (cust == null)
            //{
            //    return RedirectToAction("Create");
            //}

            var applicationDbContext = _context.Veteran.Include(v => v.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Veterans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteran = await _context.Veteran
                .Include(v => v.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veteran == null)
            {
                return NotFound();
            }

            return View(veteran);
     
        }
          
        // GET: Veterans/Create
        public IActionResult Create()
        {
           // ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Veterans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,ImageLocation,VeteranStreet,VeteranCity,VeteranState,VeteranZipCode")] Veteran veteran)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={veteran.VeteranStreet},+{veteran.VeteranCity},+{veteran.VeteranState}&key={APIKeys.GeocodeKey}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JObject geoCode = JObject.Parse(jsonResult);
                veteran.Lat = (double)geoCode["results"][0]["geometry"]["location"]["lat"];
                veteran.Long = (double)geoCode["results"][0]["geometry"]["location"]["lng"];
            }
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                veteran.IdentityUserId = userId;
                _context.Add(veteran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View (veteran);
        }

        // GET: Veterans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteran = await _context.Veteran.FindAsync(id);
            if (veteran == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", veteran.IdentityUserId);
            return View(veteran);
        }

        // POST: Veterans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,ImageLocation,VeteranStreet,VeteranCity,VeteranState,VeteranZipCode,IdentityUserId")] Veteran veteran)
        {
            if (id != veteran.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veteran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeteranExists(veteran.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", veteran.IdentityUserId);
            return View(veteran);
        }

        // GET: Veterans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteran = await _context.Veteran
                .Include(v => v.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veteran == null)
            {
                return NotFound();
            }

            return View(veteran);
        }

        // POST: Veterans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veteran = await _context.Veteran.FindAsync(id);
            _context.Veteran.Remove(veteran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeteranExists(int id)
        {
            return _context.Veteran.Any(e => e.Id == id);
        }
    }
}

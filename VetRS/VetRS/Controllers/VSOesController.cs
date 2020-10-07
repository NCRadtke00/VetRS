using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    public class VSOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VSOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VSOes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Veteran.Include(v => v.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VSOes/Details/5
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

        // GET: VSOes/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: VSOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,ImageLocation,VSOStreet,VSOCity,VSOState,VSOZipCode,IdentityUserId")] VSO vSO)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={vSO.VSOStreet},+{vSO.VSOCity},+{vSO.VSOState}&key={APIKeys.GeocodeKey}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JObject geoCode = JObject.Parse(jsonResult);
                vSO.Lat = (double)geoCode["results"][0]["geometry"]["location"]["lat"];
                vSO.Long = (double)geoCode["results"][0]["geometry"]["location"]["lng"];
            }
            if (ModelState.IsValid)
            {
                _context.Add(vSO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", vSO.IdentityUserId);
            return View(vSO);
        }

        // GET: VSOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vSO = await _context.VSO.FindAsync(id);
            if (vSO == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", vSO.IdentityUserId);
            return View(vSO);
        }

        // POST: VSOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,ImageLocation,VSOStreet,VSOCity,VSOState,VSOZipCode,IdentityUserId")] VSO vSO)
        {
            if (id != vSO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vSO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VSOExists(vSO.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", vSO.IdentityUserId);
            return View(vSO);
        }

        // GET: VSOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vSO = await _context.VSO
                .Include(v => v.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vSO == null)
            {
                return NotFound();
            }

            return View(vSO);
        }

        // POST: VSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vSO = await _context.VSO.FindAsync(id);
            _context.VSO.Remove(vSO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VSOExists(int id)
        {
            return _context.VSO.Any(e => e.Id == id);
        }
    }
}

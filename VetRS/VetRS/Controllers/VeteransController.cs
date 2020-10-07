using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetRS.Data;
using VetRS.Models;

namespace VetRS.Controllers
{
    public class VeteransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeteransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veterans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Veteran.Include(v => v.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Veterans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            VSO VsoToView = _context.VSO.Where(v => v.Id == id).SingleOrDefault();            
            return View(VsoToView);
        }

        // GET: Veterans/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Veterans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,ImageLocation,VeteranStreet,VeteranCity,VeteranState,VeteranZipCode,IdentityUserId")] Veteran veteran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veteran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", veteran.IdentityUserId);
            return View(veteran);
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

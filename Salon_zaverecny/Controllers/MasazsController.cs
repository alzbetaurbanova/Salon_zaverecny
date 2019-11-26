using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_zaverecny.Data;
using Salon_zaverecny.Models;

namespace Salon_zaverecny.Controllers
{
    public class MasazsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MasazsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Masazs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Masaz.ToListAsync());
        }

        // GET: Masazs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masaz = await _context.Masaz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masaz == null)
            {
                return NotFound();
            }

            return View(masaz);
        }

        // GET: Masazs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Masazs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Masaz masaz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masaz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masaz);
        }

        // GET: Masazs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masaz = await _context.Masaz.FindAsync(id);
            if (masaz == null)
            {
                return NotFound();
            }
            return View(masaz);
        }

        // POST: Masazs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Masaz masaz)
        {
            if (id != masaz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masaz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasazExists(masaz.ID))
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
            return View(masaz);
        }

        // GET: Masazs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masaz = await _context.Masaz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (masaz == null)
            {
                return NotFound();
            }

            return View(masaz);
        }

        // POST: Masazs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var masaz = await _context.Masaz.FindAsync(id);
            _context.Masaz.Remove(masaz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasazExists(int id)
        {
            return _context.Masaz.Any(e => e.ID == id);
        }
    }
}

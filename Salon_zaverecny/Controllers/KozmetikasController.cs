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
    public class KozmetikasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KozmetikasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kozmetikas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kozmetika.ToListAsync());
        }

        // GET: Kozmetikas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kozmetika = await _context.Kozmetika
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kozmetika == null)
            {
                return NotFound();
            }

            return View(kozmetika);
        }

        // GET: Kozmetikas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kozmetikas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Kozmetika kozmetika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kozmetika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kozmetika);
        }

        // GET: Kozmetikas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kozmetika = await _context.Kozmetika.FindAsync(id);
            if (kozmetika == null)
            {
                return NotFound();
            }
            return View(kozmetika);
        }

        // POST: Kozmetikas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Kozmetika kozmetika)
        {
            if (id != kozmetika.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kozmetika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KozmetikaExists(kozmetika.ID))
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
            return View(kozmetika);
        }

        // GET: Kozmetikas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kozmetika = await _context.Kozmetika
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kozmetika == null)
            {
                return NotFound();
            }

            return View(kozmetika);
        }

        // POST: Kozmetikas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kozmetika = await _context.Kozmetika.FindAsync(id);
            _context.Kozmetika.Remove(kozmetika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KozmetikaExists(int id)
        {
            return _context.Kozmetika.Any(e => e.ID == id);
        }
    }
}

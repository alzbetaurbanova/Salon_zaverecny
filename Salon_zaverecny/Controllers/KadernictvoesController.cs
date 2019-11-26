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
    public class KadernictvoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KadernictvoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kadernictvoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kadernictvo.ToListAsync());
        }

        // GET: Kadernictvoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadernictvo = await _context.Kadernictvo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kadernictvo == null)
            {
                return NotFound();
            }

            return View(kadernictvo);
        }

        // GET: Kadernictvoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kadernictvoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Kadernictvo kadernictvo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kadernictvo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kadernictvo);
        }

        // GET: Kadernictvoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadernictvo = await _context.Kadernictvo.FindAsync(id);
            if (kadernictvo == null)
            {
                return NotFound();
            }
            return View(kadernictvo);
        }

        // POST: Kadernictvoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Meno,Priezvisko,Cislo,Datum,Sluzba,Potvrdenie")] Kadernictvo kadernictvo)
        {
            if (id != kadernictvo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kadernictvo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KadernictvoExists(kadernictvo.ID))
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
            return View(kadernictvo);
        }

        // GET: Kadernictvoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kadernictvo = await _context.Kadernictvo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kadernictvo == null)
            {
                return NotFound();
            }

            return View(kadernictvo);
        }

        // POST: Kadernictvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kadernictvo = await _context.Kadernictvo.FindAsync(id);
            _context.Kadernictvo.Remove(kadernictvo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KadernictvoExists(int id)
        {
            return _context.Kadernictvo.Any(e => e.ID == id);
        }
    }
}

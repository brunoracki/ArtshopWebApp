using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtshopWebApp.Models;

namespace ArtshopWebApp.Controllers
{
    public class KupacsController : Controller
    {
        private readonly Artgallery981Context _context;

        public KupacsController(Artgallery981Context context)
        {
            _context = context;
        }

        // GET: Kupacs
        public async Task<IActionResult> Index()
        {
              return _context.Kupacs != null ? 
                          View(await _context.Kupacs.ToListAsync()) :
                          Problem("Entity set 'Artgallery981Context.Kupacs'  is null.");
        }

        // GET: Kupacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kupacs == null)
            {
                return NotFound();
            }

            var kupac = await _context.Kupacs
                .FirstOrDefaultAsync(m => m.Idkupac == id);
            if (kupac == null)
            {
                return NotFound();
            }

            return View(kupac);
        }

        // GET: Kupacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kupacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkupac,Ime,Prezime,Telbroj,Adresa,Mjesto,Postbroj,Email,Zemlja,Korisnickoime,Lozinka")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kupac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kupac);
        }

        // GET: Kupacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kupacs == null)
            {
                return NotFound();
            }

            var kupac = await _context.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }
            return View(kupac);
        }

        // POST: Kupacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idkupac,Ime,Prezime,Telbroj,Adresa,Mjesto,Postbroj,Email,Zemlja,Korisnickoime,Lozinka")] Kupac kupac)
        {
            if (id != kupac.Idkupac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kupac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KupacExists(kupac.Idkupac))
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
            return View(kupac);
        }

        // GET: Kupacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kupacs == null)
            {
                return NotFound();
            }

            var kupac = await _context.Kupacs
                .FirstOrDefaultAsync(m => m.Idkupac == id);
            if (kupac == null)
            {
                return NotFound();
            }

            return View(kupac);
        }

        // POST: Kupacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kupacs == null)
            {
                return Problem("Entity set 'Artgallery981Context.Kupacs'  is null.");
            }
            var kupac = await _context.Kupacs.FindAsync(id);
            if (kupac != null)
            {
                _context.Kupacs.Remove(kupac);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KupacExists(int id)
        {
          return (_context.Kupacs?.Any(e => e.Idkupac == id)).GetValueOrDefault();
        }
    }
}

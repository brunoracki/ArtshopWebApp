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
    public class IzlozbasController : Controller
    {
        private readonly Artgallery981Context _context;

        public IzlozbasController(Artgallery981Context context)
        {
            _context = context;
        }

        // GET: Izlozbas
        public async Task<IActionResult> Index()
        {
              return _context.Izlozbas != null ? 
                          View(await _context.Izlozbas.ToListAsync()) :
                          Problem("Entity set 'Artgallery981Context.Izlozbas'  is null.");
        }

        // GET: Izlozbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Izlozbas == null)
            {
                return NotFound();
            }

            var izlozba = await _context.Izlozbas
                .FirstOrDefaultAsync(m => m.Idizlozba == id);
            if (izlozba == null)
            {
                return NotFound();
            }

            return View(izlozba);
        }

        // GET: Izlozbas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Izlozbas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idizlozba,Imegalerija,Pocetak,Kraj,Drzava,Mjesto,Postbroj")] Izlozba izlozba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izlozba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(izlozba);
        }

        // GET: Izlozbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Izlozbas == null)
            {
                return NotFound();
            }

            var izlozba = await _context.Izlozbas.FindAsync(id);
            if (izlozba == null)
            {
                return NotFound();
            }
            return View(izlozba);
        }

        // POST: Izlozbas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idizlozba,Imegalerija,Pocetak,Kraj,Drzava,Mjesto,Postbroj")] Izlozba izlozba)
        {
            if (id != izlozba.Idizlozba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izlozba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzlozbaExists(izlozba.Idizlozba))
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
            return View(izlozba);
        }

        // GET: Izlozbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Izlozbas == null)
            {
                return NotFound();
            }

            var izlozba = await _context.Izlozbas
                .FirstOrDefaultAsync(m => m.Idizlozba == id);
            if (izlozba == null)
            {
                return NotFound();
            }

            return View(izlozba);
        }

        // POST: Izlozbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Izlozbas == null)
            {
                return Problem("Entity set 'Artgallery981Context.Izlozbas'  is null.");
            }
            var izlozba = await _context.Izlozbas.FindAsync(id);
            if (izlozba != null)
            {
                _context.Izlozbas.Remove(izlozba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzlozbaExists(int id)
        {
          return (_context.Izlozbas?.Any(e => e.Idizlozba == id)).GetValueOrDefault();
        }
    }
}

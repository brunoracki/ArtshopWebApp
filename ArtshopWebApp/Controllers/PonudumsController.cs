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
    public class PonudumsController : Controller
    {
        private readonly Artgallery981Context _context;

        public PonudumsController(Artgallery981Context context)
        {
            _context = context;
        }

        // GET: Ponudums
        public async Task<IActionResult> Index()
        {
            var artgallery981Context = _context.Ponuda.Include(p => p.IddjeloNavigation).Include(p => p.IdkupacNavigation);
            return View(await artgallery981Context.ToListAsync());
        }

        // GET: Ponudums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ponuda == null)
            {
                return NotFound();
            }

            var ponudum = await _context.Ponuda
                .Include(p => p.IddjeloNavigation)
                .Include(p => p.IdkupacNavigation)
                .FirstOrDefaultAsync(m => m.Idponuda == id);
            if (ponudum == null)
            {
                return NotFound();
            }

            return View(ponudum);
        }

        // GET: Ponudums/Create
        public IActionResult Create()
        {
            ViewData["Iddjelo"] = new SelectList(_context.Djelos, "Iddjelo", "Iddjelo");
            ViewData["Idkupac"] = new SelectList(_context.Kupacs, "Idkupac", "Idkupac");
            return View();
        }

        // POST: Ponudums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idponuda,Cijenaponuda,Datumponuda,Iddjelo,Idkupac")] Ponudum ponudum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponudum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddjelo"] = new SelectList(_context.Djelos, "Iddjelo", "Iddjelo", ponudum.Iddjelo);
            ViewData["Idkupac"] = new SelectList(_context.Kupacs, "Idkupac", "Idkupac", ponudum.Idkupac);
            return View(ponudum);
        }

        // GET: Ponudums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ponuda == null)
            {
                return NotFound();
            }

            var ponudum = await _context.Ponuda.FindAsync(id);
            if (ponudum == null)
            {
                return NotFound();
            }
            ViewData["Iddjelo"] = new SelectList(_context.Djelos, "Iddjelo", "Iddjelo", ponudum.Iddjelo);
            ViewData["Idkupac"] = new SelectList(_context.Kupacs, "Idkupac", "Idkupac", ponudum.Idkupac);
            return View(ponudum);
        }

        // POST: Ponudums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idponuda,Cijenaponuda,Datumponuda,Iddjelo,Idkupac")] Ponudum ponudum)
        {
            if (id != ponudum.Idponuda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponudum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PonudumExists(ponudum.Idponuda))
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
            ViewData["Iddjelo"] = new SelectList(_context.Djelos, "Iddjelo", "Iddjelo", ponudum.Iddjelo);
            ViewData["Idkupac"] = new SelectList(_context.Kupacs, "Idkupac", "Idkupac", ponudum.Idkupac);
            return View(ponudum);
        }

        // GET: Ponudums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ponuda == null)
            {
                return NotFound();
            }

            var ponudum = await _context.Ponuda
                .Include(p => p.IddjeloNavigation)
                .Include(p => p.IdkupacNavigation)
                .FirstOrDefaultAsync(m => m.Idponuda == id);
            if (ponudum == null)
            {
                return NotFound();
            }

            return View(ponudum);
        }

        // POST: Ponudums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ponuda == null)
            {
                return Problem("Entity set 'Artgallery981Context.Ponuda'  is null.");
            }
            var ponudum = await _context.Ponuda.FindAsync(id);
            if (ponudum != null)
            {
                _context.Ponuda.Remove(ponudum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PonudumExists(int id)
        {
          return (_context.Ponuda?.Any(e => e.Idponuda == id)).GetValueOrDefault();
        }
    }
}

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
    public class DjelosController : Controller
    {
        private readonly Artgallery981Context _context;

        public DjelosController(Artgallery981Context context)
        {
            _context = context;
        }

        // GET: Djelos
        public async Task<IActionResult> Index()
        {
            var artgallery981Context = _context.Djelos.Include(d => d.IdautorNavigation);
            return View(await artgallery981Context.ToListAsync());
        }

        // GET: Djelos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Djelos == null)
            {
                return NotFound();
            }

            var djelo = await _context.Djelos
                .Include(d => d.IdautorNavigation)
                .FirstOrDefaultAsync(m => m.Iddjelo == id);
            if (djelo == null)
            {
                return NotFound();
            }

            return View(djelo);
        }

        // GET: Djelos/Create
        public IActionResult Create()
        {
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor");
            return View();
        }

        // POST: Djelos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddjelo,Godinadjelo,Natpisdjelo,Cijenadjelo,Opisdjelo,Tipdjelo,Idautor,Imgdjelo")] Djelo djelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(djelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", djelo.Idautor);
            return View(djelo);
        }*/
        [HttpPost]
        public async Task<IActionResult> Create(Djelo model, IFormFile imgDjeloImage)
        {
            if (imgDjeloImage != null && imgDjeloImage.Length > 0)
            {
                // Convert the uploaded file to a byte array
                /*using (var ms = new MemoryStream())
                {
                    await imgDjeloImage.CopyToAsync(ms);
                    model.Imgdjelo = ms.ToArray();
                
                }*/ 
                using (var reader = new BinaryReader(imgDjeloImage.OpenReadStream()))
                {
                    model.Imgdjelo = reader.ReadBytes((int)imgDjeloImage.Length);
                }
            }
            // Add the new Djelo to the database
            _context.Djelos.Add(model);
            await _context.SaveChangesAsync();
            // Handle other form fields and save to database
            // ...

            // Redirect to the index page or another appropriate page
            return RedirectToAction("Index");
        }


        // GET: Djelos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Djelos == null)
            {
                return NotFound();
            }

            var djelo = await _context.Djelos.FindAsync(id);
            if (djelo == null)
            {
                return NotFound();
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", djelo.Idautor);
            return View(djelo);
        }

        // POST: Djelos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddjelo,Godinadjelo,Natpisdjelo,Cijenadjelo,Opisdjelo,Tipdjelo,Idautor,Imgdjelo")] Djelo djelo)
        {
            if (id != djelo.Iddjelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(djelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DjeloExists(djelo.Iddjelo))
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
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", djelo.Idautor);
            return View(djelo);
        }

        // GET: Djelos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Djelos == null)
            {
                return NotFound();
            }

            var djelo = await _context.Djelos
                .Include(d => d.IdautorNavigation)
                .FirstOrDefaultAsync(m => m.Iddjelo == id);
            if (djelo == null)
            {
                return NotFound();
            }

            return View(djelo);
        }
        


        // POST: Djelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Djelos == null)
            {
                return Problem("Entity set 'Artgallery981Context.Djelos'  is null.");
            }
            var djelo = await _context.Djelos.FindAsync(id);
            if (djelo != null)
            {
                _context.Djelos.Remove(djelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DjeloExists(int id)
        {
          return (_context.Djelos?.Any(e => e.Iddjelo == id)).GetValueOrDefault();
        }
    }
}

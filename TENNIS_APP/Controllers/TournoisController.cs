using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TENNIS_APP.Models;

namespace TENNIS_APP.Controllers
{
    public class TournoisController : Controller
    {
        private readonly Context _context;

        public TournoisController(Context context)
        {
            _context = context;
        }

        // GET: Tournois
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tournois.ToListAsync());
        }

        // GET: Tournois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.id == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // GET: Tournois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tournois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nom,prix,date,capacite")] Tournoi tournoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tournoi);
        }

        // GET: Tournois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois.FindAsync(id);
            if (tournoi == null)
            {
                return NotFound();
            }
            return View(tournoi);
        }

        // POST: Tournois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,nom,prix,date,capacite")] Tournoi tournoi)
        {
            if (id != tournoi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournoiExists(tournoi.id))
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
            return View(tournoi);
        }

        // GET: Tournois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournoi = await _context.Tournois
                .FirstOrDefaultAsync(m => m.id == id);
            if (tournoi == null)
            {
                return NotFound();
            }

            return View(tournoi);
        }

        // POST: Tournois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var tournoi = await _context.Tournois.FindAsync(id);
            _context.Tournois.Remove(tournoi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournoiExists(int? id)
        {
            return _context.Tournois.Any(e => e.id == id);
        }
    }
}

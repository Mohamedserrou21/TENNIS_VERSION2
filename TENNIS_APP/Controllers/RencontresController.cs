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
    public class RencontresController : Controller
    {
        private readonly Context _context;

        public RencontresController(Context context)
        {
            _context = context;
        }

        // GET: Rencontres
        public async Task<IActionResult> Index()
        {
            var context = _context.rencontres.Include(r => r.PERDANT).Include(r => r.tournoi).Include(r => r.gagnant);
            return View(await context.ToListAsync());
        }

        // GET: Rencontres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rencontre = await _context.rencontres
                .Include(r => r.PERDANT)
                .Include(r => r.gagnant)
                .Include(r => r.tournoi)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rencontre == null)
            {
                return NotFound();
            }

            return View(rencontre);
        }

        // GET: Rencontres/Create
        public IActionResult Create()
        {
            ViewData["ID_GAGNANT"] = new SelectList(_context.joueurs, "id", "nom");
            ViewData["ID_PERDANT"] = new SelectList(_context.joueurs, "id", "nom");
            ViewData["ID_Tournoi"] = new SelectList(_context.Tournois, "id", "nom");
            return View();
        }

        // POST: Rencontres/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date_tournoi,score,ID_Tournoi,ID_Gagant,ID_PERDANT")] Rencontre rencontre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rencontre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_GAGNANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.gagnant);
            ViewData["ID_PERDANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.ID_PERDANT);
            ViewData["ID_Tournoi"] = new SelectList(_context.Tournois, "id", "nom", rencontre.ID_Tournoi);
            return View(rencontre);
        }

        // GET: Rencontres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rencontre = await _context.rencontres.FindAsync(id);
            if (rencontre == null)
            {
                return NotFound();
            }
            ViewData["ID_GAGNANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.gagnant);
            ViewData["ID_PERDANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.ID_PERDANT);
            ViewData["ID_Tournoi"] = new SelectList(_context.Tournois, "id", "nom", rencontre.ID_Tournoi);
            return View(rencontre);
        }

        // POST: Rencontres/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,date_tournoi,score,ID_Tournoi,ID_Gagant,ID_PERDANT")] Rencontre rencontre)
        {
            if (id != rencontre.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rencontre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RencontreExists(rencontre.id))
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
            ViewData["ID_GAGNANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.gagnant);
            ViewData["ID_PERDANT"] = new SelectList(_context.joueurs, "id", "nom", rencontre.ID_PERDANT);
            ViewData["ID_Tournoi"] = new SelectList(_context.Tournois, "id", "nom", rencontre.ID_Tournoi);
            return View(rencontre);
        }

        // GET: Rencontres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rencontre = await _context.rencontres
                .Include(r => r.PERDANT)
                .Include(r => r.tournoi)
                .FirstOrDefaultAsync(m => m.id == id);
            if (rencontre == null)
            {
                return NotFound();
            }

            return View(rencontre);
        }

        // POST: Rencontres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var rencontre = await _context.rencontres.FindAsync(id);
            _context.rencontres.Remove(rencontre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RencontreExists(int? id)
        {
            return _context.rencontres.Any(e => e.id == id);
        }
    }
}

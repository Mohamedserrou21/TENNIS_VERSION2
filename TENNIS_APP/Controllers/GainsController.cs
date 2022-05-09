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
    public class GainsController : Controller
    {
        private readonly Context _context;

        public GainsController(Context context)
        {
            _context = context;
        }

        // GET: Gains
        public async Task<IActionResult> Index()
        {
            var context = _context.gains.Include(g => g.Nom_sponsor).Include(g => g.joueur).Include(g => g.annee_tournoi);
            return View(await context.ToListAsync());
        }

        // GET: Gains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gain = await _context.gains
                .Include(g => g.Nom_sponsor)
                .Include(g => g.joueur)
                 .Include(g => g.annee_tournoi)

                .FirstOrDefaultAsync(m => m.id == id);
            if (gain == null)
            {
                return NotFound();
            }

            return View(gain);
        }

        // GET: Gains/Create
        public IActionResult Create()
        {
            ViewData["ANNEE"] = new SelectList(_context.Tournois, "id", "date");
            ViewData["Nom_SPONSOR"] = new SelectList(_context.sponsors, "id", "nom");
            ViewData["ID_JOUEUR"] = new SelectList(_context.joueurs, "id", "nom");
            return View();
        }

        // POST: Gains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ID_JOUEUR,Nom_SPONSOR,prime,ANNEE")] Gain gain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ANNEE"] = new SelectList(_context.Tournois, "id", "date",gain.annee_tournoi);
            ViewData["Nom_SPONSOR"] = new SelectList(_context.sponsors, "id", "nom", gain.Nom_SPONSOR);
            ViewData["ID_JOUEUR"] = new SelectList(_context.joueurs, "id", "nom", gain.ID_JOUEUR);
            return View(gain);
        }

        // GET: Gains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gain = await _context.gains.FindAsync(id);
            if (gain == null)
            {
                return NotFound();
            }
            ViewData["ANNEE"] = new SelectList(_context.Tournois, "id", "date", gain.annee_tournoi);
            ViewData["Nom_SPONSOR"] = new SelectList(_context.sponsors, "id", "nom", gain.Nom_SPONSOR);
            ViewData["ID_JOUEUR"] = new SelectList(_context.joueurs, "id", "nom", gain.ID_JOUEUR);
            return View(gain);
        }

        // POST: Gains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,ID_JOUEUR,Nom_SPONSOR,prime,ANNEE")] Gain gain)
        {
            if (id != gain.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GainExists(gain.id))
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
            ViewData["ANNEE"] = new SelectList(_context.Tournois, "id", "date", gain.annee_tournoi);
            ViewData["Nom_SPONSOR"] = new SelectList(_context.sponsors, "id", "nom", gain.Nom_SPONSOR);
            ViewData["ID_JOUEUR"] = new SelectList(_context.joueurs, "id", "nom", gain.ID_JOUEUR);
            return View(gain);
        }

        // GET: Gains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gain = await _context.gains
                .Include(g => g.Nom_sponsor)
                .Include(g => g.joueur)
                .FirstOrDefaultAsync(m => m.id == id);
            if (gain == null)
            {
                return NotFound();
            }

            return View(gain);
        }

        // POST: Gains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var gain = await _context.gains.FindAsync(id);
            _context.gains.Remove(gain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GainExists(int? id)
        {
            return _context.gains.Any(e => e.id == id);
        }
    }
}

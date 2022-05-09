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
    public class SubventionsController : Controller
    {
        private readonly Context _context;

        public SubventionsController(Context context)
        {
            _context = context;
        }

        // GET: Subventions
        public async Task<IActionResult> Index()
        {
            var context = _context.Subvention.Include(s => s.NAME_SP).Include(s => s.Nom_tr);
            return View(await context.ToListAsync());
        }

        // GET: Subventions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subvention = await _context.Subvention
                .Include(s => s.NAME_SP)
                .Include(s => s.Nom_tr)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subvention == null)
            {
                return NotFound();
            }

            return View(subvention);
        }

        // GET: Subventions/Create
        public IActionResult Create()
        {

            ViewData["NOM_SPTR"] = new SelectList(_context.sponsors, "id", "nom");
            ViewData["NOM_TR"] = new SelectList(_context.Tournois, "id", "nom");
            return View();
        }

        // POST: Subventions/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Montant,NOM_TR,NAME_SPR")] Subvention subvention)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subvention);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NOM_SPTR"] = new SelectList(_context.sponsors, "id", "nom", subvention.NAME_SP);
            ViewData["NOM_TR"] = new SelectList(_context.Tournois, "id", "nom", subvention.NOM_TR);
            return View(subvention);
        }

        // GET: Subventions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subvention = await _context.Subvention.FindAsync(id);
            if (subvention == null)
            {
                return NotFound();
            }
            ViewData["NOM_SPTR"] = new SelectList(_context.sponsors, "id", "nom", subvention.NAME_SP);
            ViewData["NOM_TR"] = new SelectList(_context.Tournois, "id", "nom", subvention.NOM_TR);
            return View(subvention);
        }

        // POST: Subventions/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,Montant,NOM_TR,NAME_SPR")] Subvention subvention)
        {
            if (id != subvention.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subvention);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubventionExists(subvention.id))
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
            ViewData["NOM_SPTR"] = new SelectList(_context.sponsors, "id", "nom", subvention.NAME_SP);
            ViewData["NOM_TR"] = new SelectList(_context.Tournois, "id", "nom", subvention.NOM_TR);
            return View(subvention);
        }

        // GET: Subventions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subvention = await _context.Subvention
                .Include(s => s.NAME_SP)
                .Include(s => s.Nom_tr)
                .FirstOrDefaultAsync(m => m.id == id);
            if (subvention == null)
            {
                return NotFound();
            }

            return View(subvention);
        }

        // POST: Subventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var subvention = await _context.Subvention.FindAsync(id);
            _context.Subvention.Remove(subvention);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubventionExists(int? id)
        {
            return _context.Subvention.Any(e => e.id == id);
        }
    }
}

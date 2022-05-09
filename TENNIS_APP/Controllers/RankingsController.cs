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
    public class RankingsController : Controller
    {
        private readonly Context _context;

        public RankingsController(Context context)
        {
            _context = context;
        }

        // GET: Rankings


        public async Task<IActionResult> Index()
        {
            var context = _context.Ranking.Include(x => x.Player_Rank);

            
           
              
            return View(await _context.Ranking.ToListAsync());
        }



        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking
                .Include(x => x.Player_Rank)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // GET: Rankings/Create
        public IActionResult Create()
        {
            ViewData["RANK_PLAYER"] = new SelectList(_context.joueurs, "id", "nom");
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,score,Rank,RANK_PLAYER")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RANK_PLAYER"] = new SelectList(_context.joueurs, "id", "nom");
            return View(ranking);
        }

        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            ViewData["RANK_PLAYER"] = new SelectList(_context.joueurs, "id", "nom");
            return View(ranking);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,score,Rank,RANK_PLAYER")] Ranking ranking)
        {
            if (id != ranking.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(ranking.id))
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
            ViewData["RANK_PLAYER"] = new SelectList(_context.joueurs, "id", "nom");
            return View(ranking);
        }

        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking
                 .Include(x => x.Player_Rank)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ranking = await _context.Ranking.FindAsync(id);
            _context.Ranking.Remove(ranking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int? id)
        {
            return _context.Ranking.Any(e => e.id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TENNIS_APP.Models;

namespace TENNIS_APP.Controllers
{
    public class HeadController : Controller
    {
        private readonly Context _context;
        public HeadController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString , string search)
        {
            var players = from m in _context.joueurs
                          from x in _context.joueurs
                          select m ;
                          
            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.nom!.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(search))
            {
                players = players.Where(s => s.nom!.Contains(search));
            }

            return View(await players.ToListAsync());
           
        }






        public async Task<IActionResult> Index2( string search)
        {
           
            var players2 = from m in _context.joueurs
                           select m;

           
            if (!String.IsNullOrEmpty(search))
            {
                players2 = players2.Where(s => s.nom!.Contains(search));
            }
            return View(await players2.ToListAsync());

        }







    }
}

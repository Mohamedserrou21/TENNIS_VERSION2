using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TENNIS_APP.Models;

namespace TENNIS_APP.Controllers
{
    public class RANKController2 : Controller
    {
        private readonly Context _context;

        public RANKController2(Context context)
        {
            _context = context;
        }
        // GET: RANKController2
        public ActionResult Index()
        {

            //var context = _context.Ranking.Select(stu => new Ranking { score = stu.score }).OrderBy(x => x.score).OrderBy(x => x.score)
            //.ToList();


           var books = (from b in _context.Ranking
              join a in _context.joueurs
               on b.id equals a.id 
               orderby  b.score
                        orderby b.Rank



                        select new Ranking 
             {
                 RANK_PLAYER = b.RANK_PLAYER,
                 score = b.score,
                 Rank= b.Rank

             }).ToList();


            return View("std", books);
        }
        public ActionResult StudentListPartialView()
        { 

               
   
    var context =_context.Ranking.Select(stu=>new Ranking{score=stu.score}).ToList();
            return this.PartialView("std",context);


}

        // GET: RANKController2/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RANKController2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RANKController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RANKController2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RANKController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RANKController2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RANKController2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

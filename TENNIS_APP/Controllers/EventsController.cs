using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TENNIS_APP.Models;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JsonResult = System.Web.Mvc.JsonResult;
using ValidateAntiForgeryTokenAttribute = System.Web.Mvc.ValidateAntiForgeryTokenAttribute;

namespace TENNIS_APP.Controllers
{
    public class EventsController : Controller
    {
        private readonly Context _context;

        public EventsController(Context context)
        {
            _context = context;
        }

        // GET: Events
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            
                var events = _context.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
           
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
           
            
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = _context.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    _context.Events.Add(e);
                }

                _context.SaveChanges();
                status = true;

            
            return new JsonResult { Data = new { status = status } };
        }






        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            
            
                var v = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    _context.Events.Remove(v);
                    _context.SaveChanges();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        }









    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw8.DAL;
using hw8.Models;

namespace hw8.Controllers
{
    public class AthletesController : Controller
    {
        private TFContext db = new TFContext();

        // GET: Athletes
        public ActionResult Index()
        {
            var athletes = db.Athletes.Include(a => a.Team);
            return View(athletes.ToList());
        }

        // GET: Athletes/Details/5

        // GET: Athletes/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "ID", "NAME");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,GENDER,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
            }

            ViewBag.TeamID = new SelectList(db.Teams, "ID", "NAME", athlete.TeamID);
            return View(athlete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
    public class RaceResultsController : Controller
    {
        private TFContext db = new TFContext();

        // GET: RaceResults
        public ActionResult Index()
        {
            var raceResults = db.RaceResults.Include(r => r.Athlete).Include(r => r.Meet);
            return View(raceResults.ToList());
        }

        // GET: RaceResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }
            return View(raceResult);
        }

        // GET: RaceResults/Create
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "NAME");
            ViewBag.MeetID = new SelectList(db.Meets, "ID", "DATE");
            return View();
        }

        public ActionResult Results(int? AID)
        {
            IEnumerable<RaceResult> results = db.RaceResults.Where(x => x.AthleteID == AID).OrderBy(x => x.Meet.DATE);
            var athletes = new List<KeyValuePair<string, int>>();
            foreach (var athlete in db.Athletes)
            {
                athletes.Add(new KeyValuePair<string, int>(athlete.NAME, athlete.ID));
            }

            SelectList newList = new SelectList(athletes.Select(x => new { Text = x.Key, Value = x.Value }), "Value", "Text");
            ViewBag.newList = newList;

            return View(results);
        }

        // POST: R    aceResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,TIME,MeetID,AthleteID")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                db.RaceResults.Add(raceResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "NAME", raceResult.AthleteID);
            ViewBag.MeetID = new SelectList(db.Meets, "ID", "DATE", raceResult.MeetID);
            return View(raceResult);
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

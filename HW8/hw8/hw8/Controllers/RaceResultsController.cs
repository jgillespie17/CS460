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
using Newtonsoft.Json;

namespace hw8.Controllers
{
    public class RaceResultsController : Controller
    {
        private TFContext db = new TFContext();


        // GET: RaceResults/Create
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes, "ID", "NAME");
            ViewBag.MeetID = new SelectList(db.Meets, "ID", "DATE");
            return View();
        }

        public ActionResult Results(int? AID)
        {
            if(AID != null)
            {
                ViewBag.Success = true;
                IEnumerable<string> events = db.RaceResults.Where(x => x.AthleteID == 7).Select(x => x.NAME).Distinct();
                ViewBag.EventNameList = events;
                //Dont do kids, stay in school
                ViewBag.AthleteID = AID;
            }
            IEnumerable<RaceResult> results = db.RaceResults.Where(x => x.AthleteID == AID).OrderBy(x => x.Meet.DATE);
            var athletes = new List<KeyValuePair<string, int>>();
            foreach (var athlete in db.Athletes)
            {
                athletes.Add(new KeyValuePair<string, int>(athlete.NAME, athlete.ID));
            }
            SelectList AthleteNameList = new SelectList(athletes.Select(x => new { Text = x.Key, Value = x.Value }), "Value", "Text");
            //List<string> EventNameList = events;
            ViewBag.AthleteNameList = AthleteNameList;
            

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

        public ActionResult ApiMethod(int AID, string Event)
        { 
            var results = db.Meets.Join(db.RaceResults, m => m.ID, r => r.MeetID, (m, r) => new { Time = r.TIME, Date = m.DATE, Athlete = r.Athlete.ID, Event = r.NAME }).Where(x => x.Athlete == AID).Where(x => x.Event == Event);
            string jsonString = JsonConvert.SerializeObject(results, Formatting.Indented);
            return new ContentResult
            {
                Content = jsonString,
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }
    }
}

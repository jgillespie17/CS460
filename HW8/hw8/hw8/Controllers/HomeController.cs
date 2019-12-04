using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw8.DAL;
using hw8.Models;
using hw8.Models.ViewModel;

namespace hw8.Controllers
{
    public class HomeController : Controller
    {

        private TFContext db = new TFContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            ViewBag.success = true;
            //return View(new SelectList(db.RaceResults.OrderBy(x => x.Athlete.NAME)));
            return View(db.RaceResults.Where(x => x.Athlete.NAME.Contains(name)).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TFViewModel tfViewModel)
        {
            return View(tfViewModel);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<RaceResult> newList = db.RaceResults.Where(x => x.Athlete.ID == id);
            if(newList == null)
            {
                return HttpNotFound();
            }
                //db.RaceResults.Join(db.Meets, rr => rr.MeetID, m => m.ID, (rr, m) => new { rr, m }).Where(y => y.rr.AthleteID == id ).ToList();
            TFViewModel viewModel = new TFViewModel(newList);
            if(viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
    }
}
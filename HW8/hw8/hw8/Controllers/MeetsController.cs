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
    public class MeetsController : Controller
    {
        private TFContext db = new TFContext();
        // GET: Meets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DATE,LOCATION")] Meet meet)
        {
            if (ModelState.IsValid)
            {
                db.Meets.Add(meet);
                db.SaveChanges();
            }

            return View(meet);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw5.DAL;
using hw5.Models;

namespace hw5.Controllers
{
    public class HomeworksController : Controller
    {
        private HomeworkContext db = new HomeworkContext();

        // GET: Homeworks
        public ActionResult Index()
        {
            IList<Homework> HomeworkList = db.Homework.ToList();
            var HomeworkListOrder = HomeworkList.OrderByDescending(db => db.DueDate);
            return View(HomeworkListOrder);
        }

        // GET: Homeworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homework.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        // GET: Homeworks/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Tracker()
        {
            return View();
        }

        // POST: Homeworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Urgency,DueDate,DueTIme,Department,Course,Title,Notes")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                db.Homework.Add(homework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homework);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Tracker([Bind(Include = "ID,Urgency,DueDate,DueTIme,Department,Course,Title,Notes")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                db.Homework.Add(homework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homework);
        }

        // GET: Homeworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homework.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        // POST: Homeworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Urgency,DueDate,DueTIme,Department,Course,Title,Notes")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homework);
        }

        // GET: Homeworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homework.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        // POST: Homeworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homework homework = db.Homework.Find(id);
            db.Homework.Remove(homework);
            db.SaveChanges();
            return RedirectToAction("Index");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw6.DAL;
using hw6.Models;

namespace hw6.Controllers
{
    public class StockItemController : Controller
    {
        private WWIContext db = new WWIContext();
        // GET: StockItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.StockItems.Find(id);
            if(stockItem == null)
            {
                return HttpNotFound();
            }

            return View(stockItem);
        }
    }
}
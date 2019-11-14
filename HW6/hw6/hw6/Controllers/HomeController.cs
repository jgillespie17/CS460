using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw6.DAL;
using hw6.Models;

namespace hw6.Controllers
{
    public class HomeController : Controller
    {

        private WWIContext db = new WWIContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string name)
        {
            //IList<StockItem> items = new List<StockItem>();
            var matchingitems = db.StockItems.Where(s => s.Contains(name));
            StockItem item = db.StockItems.Find(name);           
            if(item == null)
            {
                return HttpNotFound();

            }
            return View(item);
        }
    }
}
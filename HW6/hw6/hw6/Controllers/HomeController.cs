using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hw6.DAL;
using hw6.Models;

namespace hw6.Controllers
{
    public class HomeController : Controller
    {
        //private WWIContext db = new WWIContext();
        public ActionResult Search(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //IEnumerable<StockItem> items = db.StockItems.Where(i => i.StockItemName.Contains("Name"));
            return View();
        }
    }
}

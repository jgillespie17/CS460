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

        [HttpPost]
        public ActionResult Index(string name)
        {
                 
            if(name == null)
            {
                return HttpNotFound();
            }
            IEnumerable<StockItem> items = db.StockItems.Where(i => i.StockItemName.Contains(name));
            List<string> ItemName = new List<string>();
            //IList<string> ItemName = new List<string>();
            foreach (var item in items)
            {
                ItemName.Add(item.StockItemName);
            }
            ViewBag.Success = true;
            return View(ItemName);
        }

        //public struct NameID
        //{
        //    public int id { get; set; }
        //    public string name { get; set; }
        //}
    }
}
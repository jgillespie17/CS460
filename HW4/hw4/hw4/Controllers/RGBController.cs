using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw4.Controllers
{
    public class RGBController : Controller
    {
        // GET: RGB
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index()
        {

        }
    }
}
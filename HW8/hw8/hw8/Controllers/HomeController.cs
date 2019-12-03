using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hw8.DAL;
using hw8.Models;
using hw8.Models.ViewModel;

namespace hw8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult List()
        {
            return View();
        }
    }
}
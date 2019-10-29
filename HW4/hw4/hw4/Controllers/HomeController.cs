using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace hw4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RGBColor()
        {
            string RedS = Request.QueryString["intRed"];
            int Red = Convert.ToInt32(RedS);

            string GreenS = Request.QueryString["intGreen"];
            int Green = Convert.ToInt32(GreenS);

            string BlueS = Request.QueryString["intBlue"];
            int Blue = Convert.ToInt32(BlueS);

            Color HexColor = Color.FromArgb(1, Red, Green, Blue);
            string hex = HexColor.R.ToString("X2") + HexColor.G.ToString("X2") + HexColor.B.ToString("X2");
            ViewBag.Hex = hex;

            return View();
        }
    }
}
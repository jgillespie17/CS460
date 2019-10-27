using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace hw4.Controllers
{
    public class RGBController : Controller
    {

        // GET: RGB
        public ActionResult Index()
        {
            string RedS = Request.QueryString["intRed"];
            int Red = Convert.ToInt32(RedS);
            string GreenS = Request.QueryString["intGreen"];
            int Green = Convert.ToInt32(GreenS);
            string BlueS = Request.QueryString["intBlue"];
            int Blue = Convert.ToInt32(BlueS);
            
           
            Color NewColor = Color.FromArgb(1, Red, Green, Blue);
            HexStruct output = new HexStruct
            {
                Hex = NewColor.R.ToString("X2") + NewColor.G.ToString("X2") + NewColor.B.ToString("X2")
            };
            ViewBag.Success = true;
            ViewBag.HexColor = output;




            return View();
        }
        public struct HexStruct
        {
            public string Hex { get; set; }


        }
        

       
    }
}
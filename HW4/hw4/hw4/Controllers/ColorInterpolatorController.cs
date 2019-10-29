using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace hw4.Controllers
{
    public class ColorInterpolatorController : Controller
    {
        // GET: ColorInterpolator
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(string FirstColor, string SecondColor, int? NumColor)
        {
            Color NewFirstColor = ColorTranslator.FromHtml(FirstColor);
            Color NewSecondColor = ColorTranslator.FromHtml(SecondColor);
            ColorToHSV(NewFirstColor, out double FirstHue, out double FirstSaturation, out double FirstValue);
            ColorToHSV(NewSecondColor, out double SecondHue, out double SecondSaturation, out double SecondValue);
            int num = NumColor.GetValueOrDefault();
            IList<HSV> HSVList = new List<HSV>();

            double HueInterval = (SecondHue - FirstHue) / num;
            double SaturationInterval = (SecondSaturation - FirstSaturation) / num;
            double ValueInterval = (SecondValue - FirstValue) / num;

            double HueCurrent = FirstHue;
            double SaturationCurrent = FirstSaturation;
            double ValueCurrent = FirstValue;
            for(int i = 0; i < num; i++)
            {
                HSVList.Add(new HSV { Hue = HueCurrent, Saturation = SaturationCurrent, Value = ValueCurrent });
                HueCurrent += HueInterval;
                SaturationCurrent += SaturationInterval;
                ValueCurrent += ValueInterval;
                
            }
            Console.WriteLine("SOmething");
            return View();

        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        public struct HSV
        {
            public double Hue { get; set; }
            public double Saturation { get; set; }
            public double Value { get; set; }

        }
        public struct HexList
        {
            public string Hex { get; set; }
        }

    }
}
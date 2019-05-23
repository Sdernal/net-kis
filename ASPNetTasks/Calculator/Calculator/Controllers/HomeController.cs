using System;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculator()
        {
            ViewBag.Message = "Your calculator page.";

            return View();
        }

        [HttpPost]
        public ActionResult Result(double value1, double value2, String operation)
        {
            double res = 0.0;
            switch (operation)
            {
                case "+":
                    res = value1 + value2;
                    break;
                case "-":
                    res = value1 - value2;
                    break;
                case "*":
                    res = value1 * value2;
                    break;
                case "/":
                    if (Math.Abs(value2) < 0.000001)
                        res = 12345.67890;
                    else
                    {
                        res = value1 / value2;
                    }
                    break;
                default:
                    res = 0.0;
                    break;
            }

//            return Content("Result is " + res);
            ViewData["result"] = res;
            return View();
        }
    }
}
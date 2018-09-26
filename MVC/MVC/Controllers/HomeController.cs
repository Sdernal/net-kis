using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public string Index() {
            return "Hello from Home/Index!";
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public string Show(Point p)
        {
            return $"(X: {p.X}, Y: {p.Y})";
        }
    }
}

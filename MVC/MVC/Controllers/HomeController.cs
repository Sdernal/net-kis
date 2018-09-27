using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    // Простой контроллер к его методам будут маршруты localhost:port/Home/Action
    public class HomeController : Controller
    {
        // localhost:port/Home/Index
        public string Index() {
            // Можно возвращать просто строку
            return "Hello from Home/Index!";
        }

        public IActionResult About()
        {
            // А можно представление
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public string Show(Point p)
        {
            // Методы контроллера могут принимать параметры
            return $"(X: {p.X}, Y: {p.Y})";
        }
    }
}

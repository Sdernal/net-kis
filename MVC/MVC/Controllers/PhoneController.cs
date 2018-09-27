using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PhoneController : Controller
    {
        List<Phone> phones;
        public PhoneController()
        {
            // Задаем структуру для отображения
            phones = new List<Phone>
            {
                new Phone {Id = 1, Name = "IPhone 8", Manufactorer = "Apple"},
                new Phone {Id = 2, Name = "Galaxy S9", Manufactorer = "Samsung"},
                new Phone {Id = 3, Name = "Nexus 5", Manufactorer = "Google"},
                new Phone {Id = 4, Name = "IPhone X", Manufactorer = "Apple"},
                new Phone {Id = 5, Name = "Note 8", Manufactorer = "Samsung"}
            };
        }
        public IActionResult Index()
        {
            // Использование модели
            return View(phones);
        }

        public string Show(int id)
        {
            return $"{phones[id - 1].Name}";
        }

        // Можно для метода с одним именем задавать различные типы запроса
        [HttpGet]
        public IActionResult Buy(int id)
        {
            // Вызовется при переходе на ~/Home/Buy/id
            ViewBag.PhoneId = id;
            return View(phones[id-1]);
        }

        [HttpPost]
        public string Buy(int PhoneId, string User)
        {
            // Вызовется при нажании на форме Submit
            return $"Thanks, {User}, for the order {PhoneId}";
        }
    }
}
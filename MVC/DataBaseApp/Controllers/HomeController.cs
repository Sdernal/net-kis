using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataBaseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
            // Добавим пользователей, если их еще нет
            //if (db.People.Count() == 0)
            //{
            //    db.People.Add(new Person { Id = 1, Name = "Boris", Age = 22 });
            //    db.People.Add(new Person { Id = 2, Name = "Ivan", Age = 27 });
            //    db.People.Add(new Person { Id = 3, Name = "Alice", Age = 21 });
            //    db.SaveChanges();
            //}
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.People.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

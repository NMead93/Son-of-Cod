using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCod.ViewModels;
using SonOfCod.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCod.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodDbContext _db;

        public HomeController(CodDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Newsletter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(Subscriber newSubscriber)
        {
            _db.Subscribers.Add(newSubscriber);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

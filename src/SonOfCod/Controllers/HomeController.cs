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
            PageInfo pageInfo = _db.PageInfo.FirstOrDefault(entry => entry.Id == 1);
            return View(pageInfo);
        }

        public IActionResult Newsletter()
        {
            NewsletterViewModel viewModel = new NewsletterViewModel
            {
                PageInfo = _db.PageInfo.FirstOrDefault(page => page.Id == 1)
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Subscribe(NewsletterViewModel viewModel)
        {
            _db.Subscribers.Add(new Subscriber { Email = viewModel.Subscriber.Email, Name = viewModel.Subscriber.Name });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCod.Models;

namespace SonOfCod.Controllers
{
    public class AccountController : Controller
    {
        private readonly CodDbContext _db;
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;

        public AccountController(UserManager<Admin> userManager, SignInManager<Admin> signInManager, CodDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

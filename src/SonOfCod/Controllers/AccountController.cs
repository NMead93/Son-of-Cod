using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using SonOfCod.Models;
using SonOfCod.ViewModels;
using System.Security.Claims;

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
            AdminViewModel admin = new AdminViewModel { LoginFailed = false};
            if (User.Identity.IsAuthenticated)
            {
                String currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Admin currentUser = _db.Users.FirstOrDefault(users => users.Id == currentUserId);
                admin.Subscribers = _db.Subscribers.ToList();
                admin.User = currentUser;
            }
            return View(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View(new AdminViewModel { LoginFailed = true });
            }
        }

        public IActionResult AddAdmin()
        {
            return View(new RegisterViewModel { });
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterViewModel newAdmin)
        {
            Admin registeredAdmin = new Models.Admin { UserName = newAdmin.UserName };
            IdentityResult result = await _userManager.CreateAsync(registeredAdmin, newAdmin.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

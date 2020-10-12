using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Musebox_Web_Project.Data;
using Musebox_Web_Project.Models;

namespace Musebox_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly Musebox_Web_ProjectContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Musebox_Web_ProjectContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult About()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Contact()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Store()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Gallery()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Login()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Register()
        {
            SetUserToViewBag();

            return View();
        }

        public IActionResult Cart()
        {
            SetUserToViewBag();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string email, string password)
        {
            //User userOrNull = new User()
            //{
            //    UserName = " UserNameTest",
            //    FirstName = "FTest",
            //    LastName = "LTest",
            //    Password = "123",
            //    IsManager = true
            //};


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Logedin = false;
            ViewBag.Admin = false;

            return RedirectToAction("Index", "Home");
        }

        // ToDo: Move to another place
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string firstName, string lastName, string email, string password)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.RegisterError = "Error. Model is Invalid";
                return View();
            }

            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Email, password and name cannot be empty");
            }

            // Check if user Already exists.

            {
                throw new Exception("User already exists. Pick another username");
            }

            User newUser = new User()
            {
                IsManager = false,
                UserName = firstName + " " + lastName,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };


            await _context.SaveChangesAsync();

            await SignInSession(newUser);

            return RedirectToAction("Index", "Home");
        }


        #endregion

        private async Task SignInSession(User user)
        {
            //HttpContext.Session.SetString("Logged", "1");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("FullName",user.DisplayName),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName),
                new Claim("IsManager",user.IsManager.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private void SetUserToViewBag()
        {
            Claim isAdmin = User.Claims.SingleOrDefault(c => c.Type == "IsManager");
            if (isAdmin != null)
            {
                ViewBag.Logedin = true;
                ViewBag.Admin = isAdmin.Value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Store()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Login

        // ToDo: Save to session
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {

            User userOrNull = _context.Users.SingleOrDefault<User>(user => user.Id == userName && user.Password == password);
            if (userOrNull == null)
            {
                // Incorrect!
            }
            else
            {
                // Login.
                ViewBag.IsManager = userOrNull.IsManager;
                ViewBag.FirstName = userOrNull.FirstName;
                ViewBag.LastName = userOrNull.LastName;
                ViewBag.DisplayName = userOrNull.DisplayName;
            }

            return RedirectToAction("Index");
        }

        // ToDo: Move to another place
        [HttpPost]
        public async Task<ActionResult> Register(string userName, string password, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("Username,password and name cannot be empty");
            }

            // Check if user Already exists.

            User userOrNull = _context.Users.SingleOrDefault<User>(user => user.Id == userName);
            if (userOrNull != null)
            {
                throw new Exception("Username already exists. Pick another username");
            }

            User newUser = new User()
            {
                IsManager = false,
                Id = userName,
                Password = password,
                FirstName = firstName
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        #endregion

    }
}

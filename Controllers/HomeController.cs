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
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> FilterSearchCatalog(string name, int price, string type, string brand)
        {
            var my_MuseboxContext = _context.Products.Include(p => p.Brand);
            var result = from p in my_MuseboxContext
                         select p;

            if (name != null)
            {
                result = from p in result
                         where p.ProductName.Contains(name)
                         select p;
            }
            if (price > 0)
            {
                result = from p in result
                         where p.ProductPrice <= price
                         select p;
            }
            if (type != null)
            {
                result = from p in result
                         where p.ProductType.Contains(type)
                         select p;
            }
            if (brand != null)
            {
                result = from p in result
                         where p.Brand.BrandName.Contains(brand)
                         select p;
            }

            return View("Catalog", await result.ToListAsync());
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        public async Task<IActionResult> Catalog()
        {

            var result = _context.Products.Include(p => p.Brand);
            return View(await result.ToListAsync());
        }

        public IActionResult Cart()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}

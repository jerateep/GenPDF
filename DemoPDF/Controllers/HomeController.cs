using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoPDF.Models;
using Rotativa.AspNetCore;
using System.Drawing;
using Rotativa.AspNetCore.Options;
using Size = Rotativa.AspNetCore.Options.Size;

namespace DemoPDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            Employee emp = new Employee();
            emp.id = 1;
            emp.name = "Test PDF";
            emp.job = "IT Manager";
            return new ViewAsPdf(emp)
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait

            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_parkersm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_parkersm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  MovieContext movieContexts { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext somename)
        {
            _logger = logger;
            movieContexts = somename;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAMovie()
        {
            return View("AddingMovie");
        }
        [HttpPost]
        public IActionResult AddAMovie(MovieSubmittal ms)
        {
            if (ModelState.IsValid)
            {
                movieContexts.Add(ms);
                movieContexts.SaveChanges();
                return View("Confirmation", ms);
            }
            else
            {
                return View("AddingMovie");
            }
        }

        public IActionResult Privacy()
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private  MovieContext movieContext { get; set; }

        //Constructor
        public HomeController(MovieContext somename)
        {
            movieContext = somename;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View("AddingMovie");
        }
        [HttpPost]
        public IActionResult AddAMovie(MovieSubmittal ms)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(ms);
                movieContext.SaveChanges();
                return View("Confirmation", ms);
            }
            else
            {
                return View(ms);
            }
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var submittals = movieContext.movieSubmittals
                .Include(i => i.Category)
                .OrderBy(i => i.MovieId)
                .ToList();

            return View(submittals);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var aMovie = movieContext.movieSubmittals.Single(i => i.MovieId == id);

            return View("AddingMovie", aMovie);
        }

        [HttpPost]
        public IActionResult Edit (MovieSubmittal ms2)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(ms2);
                movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View("AddingMovie",ms2);
            }

        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var aMovie = movieContext.movieSubmittals.Single(i => i.MovieId == id);
            return View(aMovie);
        }
        [HttpPost]
        public IActionResult Delete (MovieSubmittal ms3)
        {
            movieContext.movieSubmittals.Remove(ms3);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

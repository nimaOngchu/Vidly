using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult index()
        {
            var movies = _context.Movie.ToList();


            return View(movies);
        }

        //Create new movies Upload New Movie
        public ActionResult Create()
        {
            ViewBag.Heading = "Upload New Movie";
            ViewBag.ButtonText = "Upload";

            var movies = new Movie();
            return View("MovieForm",movies);
        }


        //Save MovieForm
        [HttpPost]
        public ActionResult Save(Movie movies)
        {
            if (movies.ID == 0)
            {
                _context.Movie.Add(movies);
            }
            else
            {
                var moviesInDB = _context.Movie.Single(c => c.ID == movies.ID);

                moviesInDB.Name = movies.Name;
                moviesInDB.Genre = movies.Genre;
                moviesInDB.ReleaseDate = movies.ReleaseDate;
                moviesInDB.StockNumber = movies.StockNumber;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        //Movies Edit Form
        public ActionResult Edit(int id)
        {
            ViewBag.heading = "Edit Movie";
            ViewBag.ButtonText = "Save";
            var movies = _context.Movie.Find(id);
            if (movies == null)
            {
                return HttpNotFound("No Such Customer in Database");
            }
            return View("MovieForm", movies);
        }
        public ActionResult Details(int? id)
        {
            var movies = _context.Movie.Find(id);
            return View(movies);
        }


    }
}
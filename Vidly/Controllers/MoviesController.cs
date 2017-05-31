using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

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
            var movies = _context.Movie.Include(m => m.Genre).ToList();


            return View(movies);
        }

        //Create new movies Upload New Movie
        //HTTPGET for MovieForm.cshtml
        public ActionResult Create()
        {
            ViewBag.Heading = "Upload New Movie";
            ViewBag.ButtonText = "Upload";

            var genre = _context.Genres.ToList();
            var viewModel = new MovieViewModel() {
                Genre = genre,
               
            };
            return View("MovieForm",viewModel);
        }


        //Save MovieForm
        //HTTPPOST for MovieForm.cshtml
        [HttpPost]
        public ActionResult Save(Movie moviess)
        {
            if(!ModelState.IsValid){
                var viewModel = new MovieViewModel(moviess)
                {
                    Genre = _context.Genres.ToList()
                };
            }
            if (moviess.ID == 0)
            {
                _context.Movie.Add(moviess);
            }
            else
            {
                var moviesInDB = _context.Movie.Single(c => c.ID == moviess.ID);

                moviesInDB.Name = moviess.Name;
                moviesInDB.ReleaseDate = moviess.ReleaseDate;
                moviesInDB.StockNumber = moviess.StockNumber;
                moviesInDB.GenreId = moviess.GenreId;
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
            var viewModel = new MovieViewModel()
            {
            GenreId = movies.GenreId,
            Name = movies.Name,
            Id = movies.ID,
            ReleaseDate = movies.ReleaseDate,
            StockNumber = movies.StockNumber,
            

                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Details(int? id)
        {
            var movies = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);
            return View(movies);
        }


    }
}
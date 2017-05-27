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
        public ActionResult Details(int? id)
        {
            var movies = _context.Movie.Find(id);
            return View(movies);
        }
    }
}
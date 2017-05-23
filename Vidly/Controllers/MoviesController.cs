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
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};
            var customers = new List<Customer> {
                new Customer { Name="Nima"},
                new Customer { Name="Sherpa"}
            };
            var movieViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers 
            };
        
            return View(movieViewModel);
        }
    }
}
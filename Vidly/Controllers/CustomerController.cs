using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
       
        public ActionResult Index()
        {
            var customers = new List<Customer> {
                new Customer {Id = 1, Name="Nima"},
                new Customer { Id = 2, Name="Sherpa"}
            };
            
            return View(customers);
        }

        public ActionResult Details( int ?id)
        {
            
            return View();
        }
    }
}
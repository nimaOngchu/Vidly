using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
            public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer Index
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
        }

        //Create user 
     
        public ActionResult create()
        {
            ViewBag.Heading = "Create New Customer";
            ViewBag.ButtonText = "Create";
            var MembershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = MembershipType
            };
           

            return View("CustomerForm",viewModel);
        }

        //HTTPPOST for save user 
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
              
                customerInDB.Name = customer.Name;
                customerInDB.MembershipTypeID = customer.MembershipTypeID;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.isSubcribedToNewsletter = customer.isSubcribedToNewsletter;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        //Customer Edit Form
        public ActionResult Edit(int id)
        {
            ViewBag.heading = "Edit Customer";
            ViewBag.ButtonText = "Save";
            var customers = _context.Customers.Find(id);
            if (customers == null) {
                return HttpNotFound("No Such Customer in Database");
            }
            var viewModel = new CustomerFormViewModel {
                Customer = customers,
                MembershipType = _context.MembershipType.ToList()
            };

            return View("CustomerForm",viewModel);
        }


        public ActionResult Details( int ?id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customers);
        }
    }
}
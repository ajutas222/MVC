using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // Action Modify Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                // Only storing them in the memory but db
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // not ideal as it allows the security on all objects on the page
                // TryUpdateModel(customerInDb);

                // ******************************************************
                // Alternative Solution is to declare the field individually
                customerInDb.Name = customer.Name;
                customerInDb.Dob = customer.Dob;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


                // ******************************************************
                // Using a mapper
                // Mapper.Map(customer, CustomerInDb);

            }
            // This will save them on the db
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ViewResult Index()
        {
            // ********* Commenting out to test out the dataTables
            // var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            // return View(customers);
            // Sample of data cache
            //if (MemoryCache.Default["Genres"] == null)
            //{
            //    MemoryCache.Default["Genres"] = _context.Genres.ToList();
            //}

            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
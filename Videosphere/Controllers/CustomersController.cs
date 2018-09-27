using System;
using System.Collections.Generic;
using System.Data.Entity; //metoda Include()
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videosphere.Models;

namespace Videosphere.Controllers
{
    public class CustomersController : Controller
    {
        //pobieranie customersow z bazy a nie hard-coded:

        private ApplicationDbContext _context; //convention

        public CustomersController() //convention
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //wzorzec dispose (convention).
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //teraz z bazy. Include - Eager Loading.

            //entity framework nie robi zapytania sql. pobierze customersow podczas iteracji przez ten obiekt lub .ToList().

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //tutaj query bedzie od razu przez SingleOrDefault(...).

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
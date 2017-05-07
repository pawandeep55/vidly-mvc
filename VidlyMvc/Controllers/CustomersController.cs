using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyMvc.Models;
using System.Data.Entity;

namespace VidlyMvc.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();//this context is a disposable context so we need to properly dispose via Dispose()
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {

            var customers = _context.Customers.Include(c=>c.MembershipType);

            var lin = (from cus in customers
                       where cus.Id == id
                       select cus);
            var customer = lin.SingleOrDefault();
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);//just oneline for above so many lines(lambda) 
            if (customer == null) { return HttpNotFound(); }
            // return Content("id u entered is " + customer.Id + "name is " + customer.Name);
            return View(customer);
        }
        //private IEnumerable<Customer> getCustomers()
        //{
        //    return new List<Customer>
        //    {
        //    new Customer{ Id = 1, Name = "pawan kocher" },
        //    new Customer{ Id = 2, Name = "ishu kocher" },
        //    };
        //    // return new List<Movie>() ;
        //}
    }
}
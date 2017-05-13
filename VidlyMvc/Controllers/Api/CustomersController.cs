using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyMvc.Dtos;
using VidlyMvc.Models;

namespace VidlyMvc.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //Get /api/customers
        public IHttpActionResult GetCustomer()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();


            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                NotFound();

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();

            return Ok();


            //customerindb to be passed coz we already have intitalised properties rather than creating new use existing
            // Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.Dob = customer.Dob;
            //customerInDb.IsSubscribedToNewsLetters = customer.IsSubscribedToNewsLetters;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
        }
        //PUT /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}

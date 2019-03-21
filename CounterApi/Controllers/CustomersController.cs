using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounterApi.Models;

namespace CounterApi.Controllers
{
    
    public class CustomersController : ApiController
    {
        ApplicationContext _context;
        public CustomersController()
        {
            _context = new ApplicationContext();
        }

        public IHttpActionResult Get()
        {
            return Ok(_context.Customers.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Name == customer.Name);
            if (customerInDb != null)
                return Conflict();

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok(customer);
        }
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerInDb == null)
                return NotFound();

            customerInDb.Name = customer.Name;
            _context.SaveChanges();

            return Ok(customer);

        }
    }
}

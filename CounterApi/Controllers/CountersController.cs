using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounterApi.Models;


namespace CounterApi.Controllers
{
    public class CountersController : ApiController
    {
        ApplicationContext _context;
        public CountersController()
        {
            _context = new ApplicationContext();
        }
        
       public IHttpActionResult Get()
        {
            return Ok(_context.Counters.ToList());
        }

        public IHttpActionResult Get(int customerId)
        {
            return Ok(_context.Counters.ToList().Where(c => c.CustomerId == customerId));    
        }

        public IHttpActionResult Post(Counter counter)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var counterInDb = _context.Counters.SingleOrDefault(c => c.CustomerId == counter.CustomerId && c.Ip == counter.Ip);
            if (counterInDb != null)
            {
                if (counter.A4101 != "-")
                {
                    counterInDb.Print301 = counter.Print301;
                    counterInDb.A3112 = counter.A3112;
                    counterInDb.A3122Color = counter.A3122Color;
                    counterInDb.A4101 = counter.A4101;
                    counterInDb.A4113 = counter.A4113;
                    counterInDb.A4123Color = counter.A4123Color;
                    counterInDb.Serial = counter.Serial;
                }
                counterInDb.UpdateTime = DateTime.Now;
                counterInDb.LastStatus = counter.LastStatus;
                _context.SaveChanges();
                return Ok(counter);
            }
            counter.UpdateTime = DateTime.Now;
            _context.Counters.Add(counter);
            _context.SaveChanges();
            return Ok(counter);
        }
    }
}

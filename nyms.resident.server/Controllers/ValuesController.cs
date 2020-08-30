using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nyms.resident.server.Controllers
{
    public class Address
    {
        public string Street { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string ForeName { get; set; }
        public Address Address { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Customer Get(int id)
        {
            var a = new Address() { Street = "37 Ante" };
            var c = new Customer()
            {
                Id = 24,
                ForeName = "Major",
                Address = a
            };
            return c;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

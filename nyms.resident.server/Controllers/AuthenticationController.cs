using Microsoft.Ajax.Utilities;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nyms.resident.server.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService; // add throw null
        }

        // GET: api/Authentication
        public string Get()
        {
            var k = _userService.GetTestMsg();
            return k.Result;
            // return "kkk";
        }

        // GET: api/Authentication/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authentication
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Authentication/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Authentication/5
        public void Delete(int id)
        {
        }
    }
}

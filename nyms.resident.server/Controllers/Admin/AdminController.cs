using nyms.resident.server.Filters;
using nyms.resident.server.Models;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace nyms.resident.server.Controllers.Admin
{
    [AdminAuthenticationFilter]
    public class AdminController : ApiController
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService; // throw error
        }

        // GET: api/Admin
        [Route("api/admin/test")]
        public IEnumerable<string> Get()
        {
            var u = HttpContext.Current.User.Identity.Name;
            return new string[] { "value1 admintest", "value2 admintest", u };
        }

        [HttpPut]
        [Route("api/admin/user/setpassword")]
        public IHttpActionResult SetPassword([FromBody] User user)
        {
            // validate user is [Admin]...
            

            // throw error if user.ref or pwd is null...
            
            _userService.SetPassword(user.ReferenceId, user.Password);

            return Ok("Done");

            // var u = HttpContext.Current.User.Identity.Name;
            // return new string[] { "value1 admintest", "value2 admintest", u };
        }



        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}

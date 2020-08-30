using nyms.resident.server.Filters;
using nyms.resident.server.Services.Impl;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace nyms.resident.server.Controllers.Enquiry
{
    [UserAuthenticationFilter]
    public class EnquiryController : ApiController
    {
        private readonly IUserService _userService;

        public EnquiryController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: api/Enquiry
        [Route("api/enquires/active")]
        public IEnumerable<string> Get()
        {
            var u = HttpContext.Current.User.Identity.Name;

            return new string[] { "value1 enq1", "value2 enq2", u };
        }

        // GET: api/Enquiry/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Enquiry
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Enquiry/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Enquiry/5
        public void Delete(int id)
        {
        }
    }
}

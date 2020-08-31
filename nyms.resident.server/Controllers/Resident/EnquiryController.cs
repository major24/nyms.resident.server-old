using nyms.resident.server.Filters;
using nyms.resident.server.Models;
using nyms.resident.server.Services.Impl;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace nyms.resident.server.Controllers
{
    [UserAuthenticationFilter]
    public class EnquiryController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IEnquiryService _enquiryService;

        public EnquiryController(IUserService userService, IEnquiryService enquiryService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _enquiryService = enquiryService ?? throw new ArgumentNullException(nameof(enquiryService));
        }

        // GET: api/Enquiry
        [Route("api/carehomes/enquires")]
        public IHttpActionResult GetAllEnquires()
        {
            var u = HttpContext.Current.User.Identity.Name;

            var enquires = _enquiryService.GetAll();

            if (enquires == null)
                return NotFound();

            return Ok(enquires.ToArray());
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

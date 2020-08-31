using Microsoft.Ajax.Utilities;
using nyms.resident.server.Models;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace nyms.resident.server.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthenticationController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authenticationService = authenticationService; // add throw error null??
        }

        [HttpPost]
        [Route("api/authentication/authenticate")]
        public IHttpActionResult Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            var response = _authenticationService.Authenticate(authenticationRequest);
            if (response == null)
                return BadRequest("Username or password is incorrect");

            // var x = Json<AuthenticationResponse>(response);
            // return Ok(x);
            // Newtonsoft.Json.JsonConvert()
            /*            var j = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                        var jj = JsonConvert.SerializeObject(response, Formatting.Indented, j);*/
            //return Json(response, JsonRequestBehavior.AllowGet);


            return Ok(response);
        }

    }
}

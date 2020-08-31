using Microsoft.Ajax.Utilities;
using Microsoft.SqlServer.Server;
using nyms.resident.server.Models;
using nyms.resident.server.Models.Core;
using nyms.resident.server.Services.Core;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace nyms.resident.server.Filters
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public UserAuthenticationFilter()
        {
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // checking request header value having required scheme "Bearer" or not.
            if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthFailureResult("JWT Token is Missing", request);
                return;
            }

            // Getting Token value from header values.
            var token = authorization.Parameter;

            var _authenticationService = context.Request.GetDependencyScope().GetService(typeof(IAuthenticationService)) as IAuthenticationService;
            var _userService = context.Request.GetDependencyScope().GetService(typeof(IUserService)) as IUserService;

            if (!_authenticationService.ValidateToken(token))
            {
                context.ErrorResult = new AuthFailureResult("Invalid JWT Token", request);
            }

            var identity = _authenticationService.GetClaimsIdentity(token);

            if (identity == null)
            {
                context.ErrorResult = new AuthFailureResult("Invalid Identity in JWT Token", request);
            }
            else
            {
                var refid = identity.Result.Name;
                var user = _userService.GetCareHomeUser(new Guid(refid)).Result;

                var role = user.CareHomeRoles.Where(r => r.RoleName == "Admin" || r.RoleName == "Manager").FirstOrDefault();
                if (role == null)
                {
                    context.ErrorResult = new AuthFailureResult($"Role Missing: Access denied for {user.ForeName}", request);
                }
                
                IPrincipal identityUser = new ClaimsPrincipal(identity.Result);
                context.Principal = identityUser;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }
        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            // context.ChallengeWith("Bearer", parameter);
            context.Request.Headers.Add("Bearer", parameter);
        }
    }
}














 
/*        protected Task<IPrincipal> AuthJwtToken(string token)
        {
            string username;

            if (ValidateToken(token, out username))
            {
                //to get more information from DB in order to build local identity based on username 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    // you can add more claims if needed like Roles ( Admin or normal user or something else)
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }*/

        /*private static bool ValidateToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = JwtService.GetPrincipal(token);
            if (simplePrinciple == null)
                return false;
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // You can implement more validation to check whether username exists in your DB or not or something else. 
            var refIdClaim = identity.FindFirst("ReferenceId");
            var refId = refIdClaim?.Value;
            var dbUser = ""; // _userService.getUserByReferenceId(refId);
                             // if user.roles.contains['Admin' or [manager]] then return true else false
            *//*            if (username == "mnalliah")
                        {
                            return true;
                        }*//*

            return true;
        }*/
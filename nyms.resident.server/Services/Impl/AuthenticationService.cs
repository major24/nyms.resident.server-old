﻿using nyms.resident.server.Models;
using nyms.resident.server.Services.Core;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace nyms.resident.server.Services.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthenticationService(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public string GenerateJWTToken(string name, string referenceId, int expire_in_Minutes = 30)
        {
            return _jwtService.GenerateJWTToken(name, referenceId, expire_in_Minutes);
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest)
        {
            /*// test bcrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd");
            bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);
            bool verified1 = BCrypt.Net.BCrypt.Verify("Pa$$w0rd1", passwordHash);


            var user = _userService.GetByRefereneId(new Guid("E82B2306-9927-4E42-A1FF-1983041FAE34")).Result;
            bool verified22 = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", user.Password);
*/
            // get user with user name pwd
            var userExists = _userService.GetUserByUserNamePassword(authenticationRequest.UserName, authenticationRequest.Password).Result;  //_authenticationRepository.EnsureValidUser(model.UserName, model.Password);
            if (userExists == null) return null;

            // validate pwd with bcypt??
            bool verified = BCrypt.Net.BCrypt.Verify(authenticationRequest.Password, userExists.Password);

            if (!verified)
            {
                return null;
            }

            // if not valid send error..


            // pwd is valid. get user
            var user = _userService.GetByRefereneId(userExists.ReferenceId).Result;
            user.Password = string.Empty;

            return new AuthenticationResponse(user, _jwtService.GenerateJWTToken(user.ForeName, user.ReferenceId.ToString())); //, GenerateJwtRefreshToken(user));


        }

        public bool ValidateToken(string token)
        {
            var simplePrinciple = _jwtService.GetPrincipal(token);
            if (simplePrinciple == null)
                return false;
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            string username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            // You can implement more validation to check whether username exists in your DB or not or something else. 

            return true;
        }

        public Task<ClaimsIdentity> GetClaimsIdentity(string token)
        {
            string username;
            string refId;
            var simplePrinciple = _jwtService.GetPrincipal(token);
            if (simplePrinciple == null)
                return null;

            var identity = simplePrinciple.Identity as ClaimsIdentity;

            var refIdClaim = identity.FindFirst(ClaimTypes.Name); // identity.FindFirst("ReferenceId");
            refId = refIdClaim?.Value;
            //to get more information from DB in order to build local identity based on username 
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, refId)
                    //new Claim("ReferenceId", refId)
                    // you can add more claims if needed like Roles ( Admin or normal user or something else)
                };

            identity = new ClaimsIdentity(claims, "Jwt");
            return Task.FromResult(identity);
            // IPrincipal user = new ClaimsPrincipal(identity);
            //return Task.FromResult(user);
        }

        public Task<User> GetUserByRefereneId(Guid referenceId)
        {
            return _userService.GetByRefereneId(referenceId);
        }
    }
}
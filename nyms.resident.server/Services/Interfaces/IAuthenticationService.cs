﻿using nyms.resident.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace nyms.resident.server.Services.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest authenticationRequest);
        bool ValidateToken(string token);
        // Task<IPrincipal> GetPrincipalFromToken(string token);
        Task<ClaimsIdentity> GetClaimsIdentity(string token);
        string GenerateJWTToken(string name, string referenceId, int expire_in_Minutes = 30);
        Task<User> GetUserByRefereneId(Guid referenceId);
    }
}

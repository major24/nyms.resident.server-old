using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace nyms.resident.server.Services.Core
{
    public interface IJwtService
    {
        string GenerateJWTToken(string name, string referenceId, int expire_in_Minutes = 30);
        ClaimsPrincipal GetPrincipal(string token);
    }
}

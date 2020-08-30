using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace nyms.resident.server.Services.Impl
{
    public class UserService : IUserService
    {
        public Task<string> GetTestMsg()
        {
            return Task.FromResult<string>("Hello from service");
        }
    }
}
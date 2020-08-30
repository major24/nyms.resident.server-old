using nyms.resident.server.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models
{
    public class User : IPerson
    {
        // public Guid ReferenceId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role> Roles { get; }
    }
}
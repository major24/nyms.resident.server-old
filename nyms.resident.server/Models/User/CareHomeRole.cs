using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models
{
    public class CareHomeRole
    {
        public string RoleName { get; set; }
        public string CareHomeName { get; set; }
        public Guid CareHomeReferenceId { get; set; }
    }
}
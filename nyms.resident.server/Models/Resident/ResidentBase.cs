using nyms.resident.server.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models.Resident
{
    public abstract class ResidentBase : IPerson
    {
        public string MiddleName { get; set; }
        public DateTime? Dob { get; set; } = null;
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
    }
}
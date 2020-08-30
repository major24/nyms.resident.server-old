using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models
{
    public class LocalAuthority
    {
        public int Id { get; set; }
        public int CareHomeId { get; set; }
        public string Name { get; set; }
    }
}
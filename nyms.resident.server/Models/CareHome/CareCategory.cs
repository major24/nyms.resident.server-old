using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models
{
    public class CareCategory
    {
        public CareCategory() { }
        public int Id { get; set; }
        public int CareHomeId { get; set; }
        public string Name { get; set; }
    }
}
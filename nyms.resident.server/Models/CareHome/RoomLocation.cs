using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Models
{
    public class RoomLocation
    {
        public int Id { get; set; }
        public int CareHomeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }
}
using nyms.resident.server.Models;
using nyms.resident.server.Models.Resident;
using System.Collections.Generic;

namespace nyms.resident.server.DataProviders.Interfaces
{
    public interface IEnquiryDataProvider
    {
        IEnumerable<Enquiry> GetAll();
    }
}

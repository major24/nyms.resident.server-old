using nyms.resident.server.Models;
using nyms.resident.server.Models.Resident;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nyms.resident.server.DataProviders.Interfaces
{
    public interface IEnquiryDataProvider
    {
        IEnumerable<Enquiry> GetAll();
        Task<Enquiry> GetByReferenceId(Guid referenceId);
    }
}

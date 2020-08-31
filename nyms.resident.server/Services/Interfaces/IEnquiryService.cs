using nyms.resident.server.Models;
using nyms.resident.server.Models.Resident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyms.resident.server.Services.Interfaces
{
    public interface IEnquiryService
    {
        IEnumerable<Enquiry> GetAll();
        Task<Enquiry> GetByReferenceId(Guid referenceId);
    }
}

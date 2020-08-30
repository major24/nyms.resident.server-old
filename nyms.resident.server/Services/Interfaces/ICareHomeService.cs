using nyms.resident.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyms.resident.server.Services.Interfaces
{
    public interface ICareHomeService
    {
        IEnumerable<CareHome> GetCareHomesDetails();
        CareHome GetCareHomeByReferenceId(Guid referenceId);
    }
}

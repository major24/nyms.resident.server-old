using nyms.resident.server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nyms.resident.server.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> GetByRefereneId(Guid referenceId);
        Task<User> GetUserByUserNamePassword(string userName, string password);
        Task<CareHomeUser> GetCareHomeUser(Guid referenceId);
        void SetPassword(Guid referenceId, string password);
    }
}

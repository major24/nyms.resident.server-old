using Microsoft.Ajax.Utilities;
using nyms.resident.server.DataProviders.Interfaces;
using nyms.resident.server.Models;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace nyms.resident.server.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserDataProvider _userDataProvider;
        public UserService(IUserDataProvider userDataProvider) 
        {
            _userDataProvider = userDataProvider ?? throw new ArgumentNullException(nameof(userDataProvider));
        }

        public  Task<User> GetById(int id)
        {
            throw new NotImplementedException();
/*            var user = _userDataProvider.GetById(id).Result;
            //new User() { ForeName = "Major", SurName = "Nalliah" };
            // return Task.FromResult(u);
            return Task.FromResult(user);*/
        }

        public Task<User> GetByRefereneId(Guid referenceId)
        {
            return _userDataProvider.GetUserByReferenceId(referenceId);
        }

        public Task<User> GetUserByUserNamePassword(string userName, string password)
        {
            return _userDataProvider.GetUserByUserNamePassword(userName, password);
        }

        public Task<CareHomeUser> GetCareHomeUser(Guid referenceId)
        {
            return _userDataProvider.GetCareHomeUser(referenceId);
        }

        public void SetPassword(Guid referenceId, string password)
        {
            _userDataProvider.SetPassword(referenceId, BCrypt.Net.BCrypt.HashPassword(password));
        }
    }
}
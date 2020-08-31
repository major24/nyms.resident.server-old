﻿using nyms.resident.server.DataProviders.Interfaces;
using nyms.resident.server.Models;
using nyms.resident.server.Models.Resident;
using nyms.resident.server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyms.resident.server.Services.Impl
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IEnquiryDataProvider _enquiryDataProvider;
        public EnquiryService(IEnquiryDataProvider enquiryDataProvider)
        {
            _enquiryDataProvider = enquiryDataProvider ?? throw new ArgumentNullException(nameof(enquiryDataProvider));
        }

        public IEnumerable<Enquiry> GetAll()
        {
            return _enquiryDataProvider.GetAll();
        }
    }
}
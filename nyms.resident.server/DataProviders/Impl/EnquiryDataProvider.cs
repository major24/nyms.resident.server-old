using Dapper;
using nyms.resident.server.DataProviders.Interfaces;
using nyms.resident.server.Models;
using nyms.resident.server.Models.Resident;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace nyms.resident.server.DataProviders.Impl
{
    public class EnquiryDataProvider : IEnquiryDataProvider
    {
        private readonly string _connectionString;

        public EnquiryDataProvider(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        }
        public IEnumerable<Enquiry> GetAll()
        {
            try
            {
                IEnumerable<Enquiry> enquiries = new List<Enquiry>();
                using (IDbConnection conn = new SqlConnection(_connectionString))
                {
                    string sql = @"SELECT
                      ,[reference_id] as referenceid
                      ,[care_home_id] as carehomeid
                      ,[local_authority_id] as localauthorityid
                      ,[fore_name] as forename
                      ,[sur_name] as surname
                      ,[middle_name] as middlename
                      ,[dob] as dob
                      ,[gender] as gender
                      ,[marital_status] as maritalstatus
                      ,[sw_fore_name] as swforname
                      ,[sw_sur_name] as swsurname
                      ,[sw_email_address] as swemailaddress
                      ,[sw_phone_number] as swphonenumber
                      ,[care_category_id] as carecategoryid
                      ,[care_needs] as careneeds
                      ,[stay_type] as staytype
                      ,[move_in_date] as moveindate
                      ,[family_home_visit_date] as familyhomevisitdate
                      ,[reserved_room_location] as reservedroomlocation
                      ,[reserved_room_number] as reservedroomnumber
                      ,[status] as status
                        FROM [dbo].[enquires]
                        WHERE status = 'admit'";

                    conn.Open();
                    var result = conn.QueryAsync<Enquiry>(sql).Result;
                    // todo: create sworker obj and add to enq object...
                    return result;
                }
            }
            catch (Exception ex)
            {
                // Log error
                throw new Exception("Error fetching enquires: " + ex.Message);
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash_DAL.Data
{
    public class WashRequest
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLandmark { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPincode { get; set; }
        public string CarCompany { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CarColor { get; set; }
        public string packageName { get; set; }
        public string WashNowWashNotes { get; set; }
        public DateTime? WashNowRequestTime { get; set; }
        public string WashRequestStatus { get; set; }




    }
}

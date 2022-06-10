using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CwuserProfile
    {
        public CwuserProfile()
        {
            Cwaddresses = new HashSet<Cwaddress>();
            CwcarRecords = new HashSet<CwcarRecord>();
            Cwpayments = new HashSet<Cwpayment>();
            CwscheduleLaters = new HashSet<CwscheduleLater>();
            CwwashNows = new HashSet<CwwashNow>();
            CwwashRequests = new HashSet<CwwashRequest>();
        }

        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNumber { get; set; }
        public string UserGender { get; set; }
        public string UserRole { get; set; }
        public DateTime? UserCreatedDate { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<Cwaddress> Cwaddresses { get; set; }
        public virtual ICollection<CwcarRecord> CwcarRecords { get; set; }
        public virtual ICollection<Cwpayment> Cwpayments { get; set; }
        public virtual ICollection<CwscheduleLater> CwscheduleLaters { get; set; }
        public virtual ICollection<CwwashNow> CwwashNows { get; set; }
        public virtual ICollection<CwwashRequest> CwwashRequests { get; set; }
    }
}

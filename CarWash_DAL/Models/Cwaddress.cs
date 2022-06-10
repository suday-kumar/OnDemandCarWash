using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class Cwaddress
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLandmark { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPincode { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual CwuserProfile User { get; set; }
    }
}

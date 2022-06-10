using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class Cwpackage
    {
        public Cwpackage()
        {
            CwwashRequests = new HashSet<CwwashRequest>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDetails { get; set; }
        public string PackageCost { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<CwwashRequest> CwwashRequests { get; set; }
    }
}

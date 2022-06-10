using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CwwashNow
    {
        public int WashNowId { get; set; }
        public int? UserId { get; set; }
        public DateTime? WashNowRequestTime { get; set; }
        public string WashNowSelectedCar { get; set; }
        public string WashNowCarLocation { get; set; }
        public string WashNowWashNotes { get; set; }
        public string PackageName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string RequestStatus { get; set; }

        public virtual CwuserProfile User { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CwwashRequest
    {
        public int RequestId { get; set; }
        public DateTime? RequestTime { get; set; }
        public string WashNotes { get; set; }
        public string SelectedCar { get; set; }
        public string CarLocation { get; set; }
        public string PackageName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserId { get; set; }
        public int? PackageId { get; set; }

        public virtual Cwpackage Package { get; set; }
        public virtual CwuserProfile User { get; set; }
    }
}

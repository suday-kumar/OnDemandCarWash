using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CwcarRecord
    {
        public int CarId { get; set; }
        public int? UserId { get; set; }
        public string CarCompany { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationNumber { get; set; }
        public string CarColor { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual CwuserProfile User { get; set; }
    }
}

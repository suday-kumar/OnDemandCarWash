using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class CwscheduleLater
    {
        public int SchedulelaterId { get; set; }
        public DateTime? SchedulelaterRequestTime { get; set; }
        public string SchedulelaterSelectedcar { get; set; }
        public string SchedulelaterCarLocation { get; set; }
        public string SchedulelaterWashNotes { get; set; }
        public string PackageName { get; set; }
        public DateTime? UsercreatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual CwuserProfile User { get; set; }
    }
}

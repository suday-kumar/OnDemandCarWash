using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash_DAL.Data
{
    public class washNow
    {
        public string Email { get; set; }
      //  public DateTime WashNowRequestTime { get; set; }
        public string WashNowSelectedCar { get; set; }
        public string WashNowCarLocation { get; set; }
        public string packageName { get; set; }
        public string WashNowWashNotes { get; set; }
        public int RequestStatus { get; set; }

    }

}

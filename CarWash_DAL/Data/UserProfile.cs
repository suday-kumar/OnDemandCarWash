using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarWash_DAL.Data
{
    public class UserProfile
    {

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobileNumber { get; set; }
        public string UserGender { get; set; }
        public string UserRole { get; set; }
        public string UserPassword { get; set; }

    }
}

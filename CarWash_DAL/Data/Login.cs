using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash_DAL.Data
{
    public class Login
    {
     
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }

    }
    public class LoginDto
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }

  
}

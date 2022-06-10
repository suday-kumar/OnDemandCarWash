using System;
using System.Collections.Generic;

#nullable disable

namespace CarWash_DAL.Models
{
    public partial class Cwpayment
    {
        public int PaymentId { get; set; }
        public int? UserId { get; set; }
        public string PaymentMethods { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int PayAmountBill { get; set; }
        public int Cvv { get; set; }

        public virtual CwuserProfile User { get; set; }
    }
}

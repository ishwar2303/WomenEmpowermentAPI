using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class TraineeAddressDetail
    {
        public int AddressDetailsId { get; set; }
        public int TraineeId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Pincode { get; set; }
        public string Address { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}

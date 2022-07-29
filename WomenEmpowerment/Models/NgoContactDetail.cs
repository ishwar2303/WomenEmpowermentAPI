using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class NgoContactDetail
    {
        public int NgoContactDetailsId { get; set; }
        public int NgoId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Pin { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class NgoApplication
    {
        public int NgoApplicationId { get; set; }
        public int NgoId { get; set; }
        public DateTime RequestDate { get; set; }
        public short Status { get; set; }
        public DateTime? ActionDate { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}

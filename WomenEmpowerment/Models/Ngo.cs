using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class Ngo
    {
        public Ngo()
        {
            NgoApplications = new HashSet<NgoApplication>();
            NgoContactDetails = new HashSet<NgoContactDetail>();
            NgoDetails = new HashSet<NgoDetail>();
        }

        public int NgoId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<NgoApplication> NgoApplications { get; set; }
        public virtual ICollection<NgoContactDetail> NgoContactDetails { get; set; }
        public virtual ICollection<NgoDetail> NgoDetails { get; set; }
    }
}

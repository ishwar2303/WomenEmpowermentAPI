using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class NgoDetail
    {
        public int NgoDetailsId { get; set; }
        public int NgoId { get; set; }
        public string OrganisationName { get; set; }
        public string ChairmanName { get; set; }
        public string Pan { get; set; }
        public string SecretaryName { get; set; }
        public string Website { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class NgoDetail
    {
        public int NgoDetailsId { get; set; }
        [Required(ErrorMessage ="NgoId is required")]
        public int NgoId { get; set; }
        [Required(ErrorMessage = "Organisation name is required")]
        public string OrganisationName { get; set; }
        [Required(ErrorMessage = "Chairman name is required")]
        public string ChairmanName { get; set; }
        [Required]
        [StringLength(9,ErrorMessage ="Only 9 characters allowed")]
        public string Pan { get; set; }
        public string SecretaryName { get; set; }
        public string Website { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}

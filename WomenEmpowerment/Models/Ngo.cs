using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
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
        [Required(ErrorMessage ="User id is required")]
        [DataType(DataType.EmailAddress)]
        
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [MaxLength(12,ErrorMessage ="Maximum allowable length is 12")]
        [MinLength(4,ErrorMessage ="Minimum length is 4")]
        public string Password { get; set; }

        public virtual ICollection<NgoApplication> NgoApplications { get; set; }
        public virtual ICollection<NgoContactDetail> NgoContactDetails { get; set; }
        public virtual ICollection<NgoDetail> NgoDetails { get; set; }
    }
}

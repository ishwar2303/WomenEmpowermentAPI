using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class NgoContactDetail
    {
        public int NgoContactDetailsId { get; set; }
        public int NgoId { get; set; }
        [Required]
        [StringLength(maximumLength: 15,MinimumLength =4,ErrorMessage ="Maximum length is 15 and minimum length is 4")]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        [StringLength(6,ErrorMessage ="PIN is of 6 digit")]
        public int Pin { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Only 10 digits allowed")]
        public long ContactNo { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}

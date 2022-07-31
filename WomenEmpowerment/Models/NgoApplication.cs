using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class NgoApplication
    {
        public int NgoApplicationId { get; set; }
        [Required]
        public int NgoId { get; set; }
        [DataType(DataType.Date,ErrorMessage ="Invalid Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime RequestDate { get; set; }
        public short Status { get; set; }
        [DataType(DataType.Date,ErrorMessage ="Invalid Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime? ActionDate { get; set; }

        public virtual Ngo Ngo { get; set; }
    }

   
}

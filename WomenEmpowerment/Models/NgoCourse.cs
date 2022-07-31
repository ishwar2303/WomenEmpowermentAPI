using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class NgoCourse
    {
        public int NgoCoursesId { get; set; }
        [Required(ErrorMessage ="NgoId required")]
        public int NgoId { get; set; }
        [Required(ErrorMessage ="CourseId required")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Ngo Ngo { get; set; }
    }
}

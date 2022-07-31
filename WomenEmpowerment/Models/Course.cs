using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage ="Course code is required")]
        [MaxLength(6,ErrorMessage ="MAximum allowable code length is 6")]
        public string Code { get; set; }
        [Required(ErrorMessage ="Course description is required")]
        public string Description { get; set; }
    }
}

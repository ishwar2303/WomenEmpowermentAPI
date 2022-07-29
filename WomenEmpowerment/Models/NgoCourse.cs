using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class NgoCourse
    {
        public int NgoCoursesId { get; set; }
        public int NgoId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Ngo Ngo { get; set; }
    }
}

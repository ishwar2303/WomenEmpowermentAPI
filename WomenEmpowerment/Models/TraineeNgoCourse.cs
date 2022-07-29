using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class TraineeNgoCourse
    {
        public int TraineeNgoCourseId { get; set; }
        public int TraineeId { get; set; }
        public int NgoId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Ngo Ngo { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}

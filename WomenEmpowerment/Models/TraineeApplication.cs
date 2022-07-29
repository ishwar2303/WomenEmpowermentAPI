using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class TraineeApplication
    {
        public int TraineeApplicationId { get; set; }
        public int TraineeId { get; set; }
        public DateTime RequestDate { get; set; }
        public short Status { get; set; }
        public DateTime? ActionDate { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}

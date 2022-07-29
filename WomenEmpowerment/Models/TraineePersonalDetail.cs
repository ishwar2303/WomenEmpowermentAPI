using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class TraineePersonalDetail
    {
        public int PersonalDetailsId { get; set; }
        public int TraineeId { get; set; }
        public string EmailId { get; set; }
        public long Aadhaar { get; set; }
        public string Pan { get; set; }
        public string Religion { get; set; }
        public string Category { get; set; }
        public string MaritalStatus { get; set; }
        public bool PersonWithDisability { get; set; }
        public string DisabilityType { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}

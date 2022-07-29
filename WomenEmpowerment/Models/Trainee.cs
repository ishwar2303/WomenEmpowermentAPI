using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class Trainee
    {
        public Trainee()
        {
            TraineeAddressDetails = new HashSet<TraineeAddressDetail>();
            TraineeApplications = new HashSet<TraineeApplication>();
            TraineeFamilyDetails = new HashSet<TraineeFamilyDetail>();
            TraineePersonalDetails = new HashSet<TraineePersonalDetail>();
        }

        public int TraineeId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TraineeAddressDetail> TraineeAddressDetails { get; set; }
        public virtual ICollection<TraineeApplication> TraineeApplications { get; set; }
        public virtual ICollection<TraineeFamilyDetail> TraineeFamilyDetails { get; set; }
        public virtual ICollection<TraineePersonalDetail> TraineePersonalDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace WomenEmpowerment.Models
{
    public partial class TraineeFamilyDetail
    {
        public int FamilyDetailsId { get; set; }
        public int TraineeId { get; set; }
        public string MotherName { get; set; }
        public string MotherDesignation { get; set; }
        public string FatherName { get; set; }
        public string FatherDesignation { get; set; }
        public string HusbandName { get; set; }
        public short NumberOfChildren { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class ParentStudent
    {
        public int ParentStudentId { get; set; }
        public int StudentPartyId { get; set; }
        public int ParentPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Parent ParentParty { get; set; }
        public Student StudentParty { get; set; }
    }
}

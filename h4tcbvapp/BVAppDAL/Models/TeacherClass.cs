using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class TeacherClass
    {
        public int TeacherClassId { get; set; }
        public int ClassId { get; set; }
        public int TeacherPartyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Class Class { get; set; }
        public Teacher TeacherParty { get; set; }
    }
}

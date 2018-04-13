using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            TeacherClass = new HashSet<TeacherClass>();
        }

        public int PartyId { get; set; }
        public string TeacherIdentifier { get; set; }
        public string AvailHoursStart { get; set; }
        public string AvailHoursEnd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party Party { get; set; }
        public ICollection<TeacherClass> TeacherClass { get; set; }
    }
}

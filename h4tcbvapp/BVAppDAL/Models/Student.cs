using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Student
    {
        public Student()
        {
            ParentStudent = new HashSet<ParentStudent>();
            StudentClass = new HashSet<StudentClass>();
        }

        public int PartyId { get; set; }
        public string StudentIdentifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party Party { get; set; }
        public ICollection<ParentStudent> ParentStudent { get; set; }
        public ICollection<StudentClass> StudentClass { get; set; }
    }
}

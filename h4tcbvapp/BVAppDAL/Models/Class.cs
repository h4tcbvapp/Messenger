using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Class
    {
        public Class()
        {
            StudentClass = new HashSet<StudentClass>();
            TeacherClass = new HashSet<TeacherClass>();
        }

        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public string ClassName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Grade Grade { get; set; }
        public ICollection<StudentClass> StudentClass { get; set; }
        public ICollection<TeacherClass> TeacherClass { get; set; }
    }
}

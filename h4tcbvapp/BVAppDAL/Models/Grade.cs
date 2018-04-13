using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Class = new HashSet<Class>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Class> Class { get; set; }
    }
}

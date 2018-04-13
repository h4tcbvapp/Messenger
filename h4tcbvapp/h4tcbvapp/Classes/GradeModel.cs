using System;
using System.Collections;
using System.Collections.Generic;

namespace h4tcbvapp.Classes
{
    public class GradeModel
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GradeModel()
        {
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace h4tcbvapp.Classes
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string StudentIdentifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public StudentModel()
        {

        }
    }
}

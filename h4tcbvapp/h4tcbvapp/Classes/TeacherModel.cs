using System;
using System.Collections;
using System.Collections.Generic;

namespace h4tcbvapp.Classes
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string TeacherIdentifier { get; set; }
        public string AvailHoursStart { get; set; }
        public string AvailHoursEnd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public TeacherModel()
        {
        }
    }
}

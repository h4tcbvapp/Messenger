using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class StudentClass
    {
        public int StudentClassId { get; set; }
        public int PartyId { get; set; }
        public int ClassId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Class Class { get; set; }
        public Student Party { get; set; }
    }
}

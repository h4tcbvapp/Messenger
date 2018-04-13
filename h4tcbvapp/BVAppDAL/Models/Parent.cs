using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Parent
    {
        public Parent()
        {
            ParentStudent = new HashSet<ParentStudent>();
        }

        public int PartyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<ParentStudent> ParentStudent { get; set; }
    }
}

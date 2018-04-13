using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Admin
    {
        public int PartyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party Party { get; set; }
    }
}

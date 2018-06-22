using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class PartyType
    {
        public PartyType()
        {
            Party = new HashSet<Party>();
        }

        public int PartyTypeId { get; set; }
        public string PartyType1 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Party> Party { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public int PhoneCareerId { get; set; }
        public int PartyId { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party Party { get; set; }
        public PhoneCareer PhoneCareer { get; set; }
    }
}

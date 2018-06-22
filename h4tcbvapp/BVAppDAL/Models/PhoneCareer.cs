using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class PhoneCareer
    {
        public PhoneCareer()
        {
            Phone = new HashSet<Phone>();
        }

        public int PhoneCareerId { get; set; }
        public string PhoneCareerName { get; set; }
        public string Smsgateway { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Phone> Phone { get; set; }
    }
}

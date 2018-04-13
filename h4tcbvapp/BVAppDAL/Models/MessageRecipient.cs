using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class MessageRecipient
    {
        public int MessageRecipientId { get; set; }
        public int MessageId { get; set; }
        public int? ParentPartyId { get; set; }
        public int? StudentPartyId { get; set; }
        public int? TeacherPartyId { get; set; }
        public DateTime? ReadDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Message Message { get; set; }
        public Party ParentParty { get; set; }
        public Party StudentParty { get; set; }
        public Party TeacherParty { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Message
    {
        public Message()
        {
            MessageRecipient = new HashSet<MessageRecipient>();
        }

        public int MessageId { get; set; }
        public int SenderPartyId { get; set; }
        public int MessageGroupId { get; set; }
        public string MessageText { get; set; }
        public string SentToClass { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party SenderParty { get; set; }
        public ICollection<MessageRecipient> MessageRecipient { get; set; }
    }
}

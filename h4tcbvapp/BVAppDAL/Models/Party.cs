using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Party
    {
        public Party()
        {
            Message = new HashSet<Message>();
            MessageRecipientParentParty = new HashSet<MessageRecipient>();
            MessageRecipientStudentParty = new HashSet<MessageRecipient>();
            MessageRecipientTeacherParty = new HashSet<MessageRecipient>();
            Phone = new HashSet<Phone>();
        }

        public int PartyId { get; set; }
        public int PartyTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public PartyType PartyType { get; set; }
        public Account Account { get; set; }
        public Admin Admin { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<MessageRecipient> MessageRecipientParentParty { get; set; }
        public ICollection<MessageRecipient> MessageRecipientStudentParty { get; set; }
        public ICollection<MessageRecipient> MessageRecipientTeacherParty { get; set; }
        public ICollection<Phone> Phone { get; set; }
    }
}

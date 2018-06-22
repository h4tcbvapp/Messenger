﻿using System;
using System.Collections.Generic;

namespace BVAppDAL.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int PartyId { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Party Party { get; set; }
    }
}

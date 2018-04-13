using System;
using System.Collections;
using System.Collections.Generic;

namespace hh4tcbvapp.Classes
{
    public class NotificationModel
    {
        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }
   
        public Dictionary<string, string> Recipients
        {
            get;
            set;
        }

        public NotificationModel()
        {
            Recipients = new Dictionary<string, string>();
        }
    }
}

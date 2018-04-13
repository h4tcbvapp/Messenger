using System;
using System.Collections;
using System.Collections.Generic;

namespace h4tcbvapp.Classes
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

    public class NotificationRecipient
    {
        public int PartyId
        {
            get;
            set;
        }

        public string RecipName
        {
            get;
            set;
        }

        public string RecipAddress
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string SmsGateway
        {
            get;
            set;
        }
    }

    public class NotificationSender
    {
        public string ApiKey
        {
            get;
            set;
        }

        public string FromAddress
        {
            get;
            set;
        }

        public string FromName
        {
            get;
            set;
        }

        public string MessageFormat
        {
            get;
            set;
        }

        public bool DisplayRecipients
        {
            get;
            set;
        }
    }

}

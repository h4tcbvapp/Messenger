using BVAppDAL.DAL;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using h4tcbvapp.Classes;

namespace h4tcbvapp.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        [HttpPost("[action]"), Authorize]
        public MockMessageEntity Post(Message message)
        {
            var accountDAL = new AccountDAL();

            var recipList = new List<NotificationRecipient>();

            // parse the array of recipient ids and create NotificationRecipients
            foreach (var item in message.To)
            {
                var recipJson = accountDAL.RecipientSelect(int.Parse(item));

                if (!string.IsNullOrWhiteSpace(recipJson))
                {
                    recipList.Add(JsonConvert.DeserializeObject<NotificationRecipient>(recipJson));
                }
            }

            // TODO: complete the logic to retrieve information to save a new message


            // TODO: add logic after a successful message save to send a Notification

            return new MockMessageEntity { ID = 1 };

        }
    }

    public class MockMessageEntity
    {
        public int ID { get; set; }
    }

    public class Message
    {
        public string From { get; set; }
        public string[] To { get; set; }
        public string Text { get; set; }
    }
}

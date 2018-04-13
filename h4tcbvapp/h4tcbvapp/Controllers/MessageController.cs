using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace h4tcbvapp.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        [HttpPost("[action]"), Authorize]
        public MockMessageEntity Post(Message message)
        {
            return new MockMessageEntity { ID = 42 };
        }
    }

    public class MockMessageEntity
    {
        public int ID { get; set; }
    }

    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace h4tcbvapp.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Message> GetMessages()
        {
            return new Message[]{
                new Message{From="yuri", Text="hi"},
                new Message{From="dude", Text="yo"}
            };
        }
    }


}

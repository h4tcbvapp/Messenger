using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvnotification.Classes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace h4tcbvnotification.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);

            var result = new Dictionary<string, object>();
            result.Add("UrlPath", client.UrlPath);
            result.Add("MediaType", client.MediaType);
            result.Add("Version", client.Version);

            var recips = new Dictionary<string, string>();
            recips.Add("6153007626@txt.att.net", "Paul Cox");
            recips.Add("6155857169@messaging.sprintpcs.com", "Damon Cerveny");

            result.Add("Recipients", recips);

            return Json(result);
        }

        [HttpPost]
        public async Task Index([FromBody] NotificationModel message)
        {
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var fromAddr = _configuration.GetSection("SENDGRID_FROM_EMAIL").Value;
            var fromName = _configuration.GetSection("SENDGRID_FROM_NAME").Value;
            var from = new EmailAddress(fromAddr, fromName);
            var bodyFormat = _configuration.GetSection("SENDGRID_MSG_FORMAT").Value;

            List<EmailAddress> tos = new List<EmailAddress>();
            foreach (var item in message.Recipients)
            {
                tos.Add(new EmailAddress(item.Key, item.Value));
            }

            var subject = message.Subject;
            var textContent = (bodyFormat.ToLower() == "text" ? message.Body : string.Empty);
            var htmlContent = (bodyFormat.ToLower() == "text" ? string.Empty : message.Body);

            // set the following to true if you want recipients to see each other's mail id
            var displayRecipients = false;
            try
            {
                bool.TryParse(_configuration.GetSection("SENDGRID_DISPLAY_RECIPIENTS").Value, out displayRecipients);
            }
            catch (System.Exception)
            {
                // if the evaluation fails, set the variable to false
                displayRecipients = false;
            }

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, textContent, htmlContent, displayRecipients);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

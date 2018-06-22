﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using h4tcbvapp.Classes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace h4tcbvapp.Controllers
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
            var sender = new NotificationSender();
            _configuration.GetSection("SendGrid").Bind(sender);
            var apiKey = sender.ApiKey;
            var client = new SendGridClient(apiKey);
            var fromAddr = sender.FromAddress;
            var fromName = sender.FromName;
            var from = new EmailAddress(fromAddr, fromName);
            var bodyFormat = sender.MessageFormat;

            List<EmailAddress> tos = new List<EmailAddress>();
            foreach (var item in message.Recipients)
            {
                tos.Add(new EmailAddress(item.Key, item.Value));
            }

            var subject = message.Subject;
            var textContent = (bodyFormat.ToLower() == "text" ? message.Body : string.Empty);
            var htmlContent = (bodyFormat.ToLower() == "text" ? string.Empty : message.Body);

            // set the following to true if you want recipients to see each other's mail id
            var displayRecipients = sender.DisplayRecipients;

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, textContent, htmlContent, displayRecipients);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

﻿
namespace PriceAlertApp.Models
{
    public class MailRequest
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}

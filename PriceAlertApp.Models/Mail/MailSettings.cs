using System;

namespace PriceAlertApp.Models.Mail
{
    public class MailSettings
    {
        public MailSettings(string mail, string displayName, string password, string host, int port)
        {
            Mail = mail;
            DisplayName = displayName;
            Password = password;
            Host = host;
            Port = port;
        }

        public string Mail { get; private set; }

        public string DisplayName { get; private set; }

        public string Password { get; private set; }

        public string Host { get; private set; }

        public int Port { get; private set; }
    }
}

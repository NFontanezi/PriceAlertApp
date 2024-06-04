

namespace PriceAlertApp.Models.Mail
{
    public class MailCredential
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _domain;

        public MailCredential(string userName, string password, string domain)
        {
            _userName = userName;
            _password = password;
            _domain = domain;
        }

        public string UserName => _userName;

        public string Password => _password;

        public string Domain => _domain;
    }
}

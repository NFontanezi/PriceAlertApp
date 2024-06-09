using PriceAlertApp.Models.Mail;

namespace PriceAlertApp.Services.Mail
{
    public class MailCredentialFactory : IMailCredentialFactory
    {
        private static IAppSettingsHelper _appSettingsHelper;


        public void Configure(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper;
        }

        public static MailCredential BuildCredential()
        {
            var user = _appSettingsHelper.GetAppSettings("MailCredentials:UserName");
            var password = _appSettingsHelper.GetAppSettings("MailCredentials:Password");
            var domain = _appSettingsHelper.GetAppSettings("MailCredentials:Domain");
            var host = _appSettingsHelper.GetAppSettings("MailCredentials:Host");
            var port = Convert.ToInt32(_appSettingsHelper.GetAppSettings("MailCredentials:Port"));

            return new MailCredential(user, password, domain, host, port);
        }
    }
}

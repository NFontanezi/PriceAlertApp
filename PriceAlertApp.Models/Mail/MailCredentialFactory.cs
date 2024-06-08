
using PriceAlertApp.Services;
using Microsoft.Extensions.Configuration;

namespace PriceAlertApp.Models.Mail
{
    public class MailCredentialFactory
    {
        private static IAppSettingsHelper _appSettingsHelper;
        private static IConfiguration _config;


        public static void MailCredentialFactoryConfigure(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = new AppSettingsHelper(_config) ?? throw new ArgumentNullException(nameof(appSettingsHelper));
        }

        public static MailCredential BuildCredential()
        {
            MailCredentialFactoryConfigure(_appSettingsHelper);
            var user = _appSettingsHelper.GetAppSettings("MailCredentials:UserName");
            var password = _appSettingsHelper.GetAppSettings("MailCredentials:Password");
            var domain = _appSettingsHelper.GetAppSettings("MailCredentials:Domain");
            var host = _appSettingsHelper.GetAppSettings("MailCredentials:Host");
            var port = Convert.ToInt32(_appSettingsHelper.GetAppSettings("MailCredentials:Port"));

            return new MailCredential(user, password, domain, host, port);
        }
    }
}

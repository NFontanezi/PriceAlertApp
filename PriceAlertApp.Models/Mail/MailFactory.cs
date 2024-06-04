

using PriceAlertApp.Services;

namespace PriceAlertApp.Models.Mail
{
    public class MailFactory
    {
        private static IAppSettingsHelper _appSettingsHelper;

        public static void MailCredentialFactoryConfigure(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper ?? throw new ArgumentNullException(nameof(appSettingsHelper));
        }

        public static MailCredential BuildCredential()
        {
            var user = _appSettingsHelper.GetAppSettings("MailCredentials:UserName");
            var password = _appSettingsHelper.GetAppSettings("MailCredentials:Password");
            var domain = _appSettingsHelper.GetAppSettings("MailCredentials:domain");

            return new MailCredential(user, password, domain);
        }
    }
}

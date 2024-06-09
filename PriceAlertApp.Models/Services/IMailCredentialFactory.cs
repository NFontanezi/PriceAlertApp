using PriceAlertApp.Services;

namespace PriceAlertApp.Models.Services
{
    public interface IMailCredentialFactory
    {
        void Configure(IAppSettingsHelper appSettingsHelper);
    }
}

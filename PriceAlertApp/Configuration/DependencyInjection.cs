using AlertApp.Services.Mail;
using Microsoft.Extensions.DependencyInjection;
using PriceAlertApp.Models.Mail;
using PriceAlertApp.Services;
using PriceAlertApp.Services.AlphaVantageApiServices;
using PriceAlertApp.Services.Stocks;

namespace PriceAlertApp.Console.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveArgusDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettingsHelper, AppSettingsHelper>();

            //repositories

            //services
            services.AddScoped<IStockService, StockService>();
            services.AddSingleton<IAlphaWebApiService, AlphaWebApiService>();


            //mail
            services.AddScoped<IMailServiceClient, MailServiceClient>();
            services.AddSingleton<IMailService, MailService>(s =>
            {
                var credential = MailCredentialFactory.BuildCredential();
                var settings = new MailSettings(
                    mail: credential.UserName,
                    displayName: $"{credential.Domain} - Execution",
                    password: credential.Password,
                    host: "smtp.office365.com",
                    port: 587);

                return new MailService();
            });

            return services;
        }
    }
}

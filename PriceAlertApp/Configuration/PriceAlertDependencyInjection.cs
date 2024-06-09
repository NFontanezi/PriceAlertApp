using Microsoft.Extensions.DependencyInjection;
using PriceAlert;
using PriceAlertApp.Services.AlphaVantageApiServices;
using PriceAlertApp.Services.Mail;
using PriceAlertApp.Services.Stocks;
using PriceAlertApp.Services;

namespace PriceAlertApp.Console.Configuration
{
    public static class PriceAlertDependencyInjection
    {
        public static ServiceProvider BuildServiceProvider()
        {
            //configs
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<Program>();
            serviceCollection.AddSingleton<IAppSettingsHelper, AppSettingsHelper>();
            serviceCollection.AddSingleton<IMailCredentialFactory, MailCredentialFactory>();

            //services
            serviceCollection.AddTransient<IStockService, StockService>();
            serviceCollection.AddTransient<IMailService, MailService>();
            serviceCollection.AddTransient<IMailServiceClient, MailServiceClient>();
            serviceCollection.AddTransient<IAlphaWebApiService, AlphaWebApiService>();
            serviceCollection.AddTransient<IAlphaWebApiExecutor, AlphaWebApiExecutor>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // email config
            var appSettingsHelper = serviceProvider.GetService<IAppSettingsHelper>();
            var mailCredentialFactory = serviceProvider.GetService<IMailCredentialFactory>();
            mailCredentialFactory.Configure(appSettingsHelper);

            return serviceProvider;
        }
    }
}

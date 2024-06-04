


using Microsoft.Extensions.Configuration;

namespace PriceAlertApp.Services
{
    public class AppSettingsHelper : IAppSettingsHelper
    {
        public string GetAppSettings(string key)
        {
            // Lendo a chave do arquivo de configuração
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public string GetConnectionString(string name)
        {
            // Lendo a connection string do arquivo de configuração
            return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
        }
    }

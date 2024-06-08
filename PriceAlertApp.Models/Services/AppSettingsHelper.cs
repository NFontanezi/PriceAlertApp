using Microsoft.Extensions.Configuration;


namespace PriceAlertApp.Services
{
    public class AppSettingsHelper : IAppSettingsHelper
    {
        private IConfiguration _config;

        public AppSettingsHelper(IConfiguration config)
        {
            try
            {
                LoadConfigFilesByEnvironment();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void LoadConfigFilesByEnvironment()
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);


            _config = configuration.Build();
        }

        public string GetAppSettings(string section)
        {
            return _config.GetSection(section).Value;
        }

    }
}

using Microsoft.Extensions.DependencyInjection;
using PriceAlertApp.Models.Mail;
using PriceAlertApp.Models.Services;
using PriceAlertApp.Services;
using PriceAlertApp.Services.AlphaVantageApiServices;
using PriceAlertApp.Services.Mail;
using PriceAlertApp.Services.Stocks;
using System;
using System.Text.RegularExpressions;

namespace PriceAlert
{
    public class Program
    {
        private static bool _run = true;
        private static string _argument = string.Empty; // "RunPriceAlert_PETR4_2.34_35"; 
        private static double _inputPriceMin;
        private static double _inputPriceMax;
        private static string _stock = string.Empty;

        private readonly IStockService _loader;

        public Program(IStockService loader)
        {
            _loader = loader;

        }


        static async Task Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();
            var program = serviceProvider.GetService<Program>();

            if (args != null && args.Length > 0)
            {
                _argument = args[0];
                await program.RunAsync();
            }


            else
            {
                Console.WriteLine("Please follow the instructions to run the app properly");
                Environment.Exit(0);
            }

        }

        public async Task RunAsync()
        {

            Console.WriteLine("Alert app started...");

            while (_run)
            {
                if (!ValidateInputs())
                {
                    Console.WriteLine($"{_argument}");
                    Console.WriteLine("Inputs are not valid. Try again");
                    _run = false;
                    break;

                }
                else
                    await _loader.CheckStockPrice(_stock, _inputPriceMin, _inputPriceMax);


                Console.WriteLine("Alert running...");
                await Task.Delay(5 * 60 * 1000);

            }

        }


        private bool ValidateInputs()
        {
            try
            {
                var args = _argument.Split('_');

                if (IsRegexSuccess(_argument))
                {
                    Double.TryParse(args[2], out var minPrice);
                    Double.TryParse(args[3], out var maxPrice);

                    if (minPrice > maxPrice || !minPrice.Equals(maxPrice))
                    {
                        _stock = args[1];
                        _inputPriceMin = minPrice;
                        _inputPriceMax = maxPrice;
                        return true;
                    }

                    return false;

                }

                else
                    return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: system cannot read the inputs. Please follow pattern instructions\n {ex.Message} ");
                return false;

            }

        }

        private bool IsRegexSuccess(string args)
        {
            var pattern = @"\b[RunPriceAlert_]+[A-Z0-9]+(?:\.[A-Z]+)?_[\d.]+_[\d.]+";

            var regex = Regex.Match(args, pattern);

            if (regex.Success)
                return true;
            else
                return false;
        }

        private static ServiceProvider BuildServiceProvider()
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

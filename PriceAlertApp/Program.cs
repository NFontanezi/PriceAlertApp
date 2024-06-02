using PriceAlertApp.Services.Stocks;
using System;

namespace PriceAlert
{
    public class Program
    {
        private static bool _run = true;
        private static string _argument = "PETR4_2.3_24";
        private static double _inputPriceMin;
        private static double _inputPriceMax;
        private static string _stock = string.Empty;

        private readonly IStockLoader _loader;

        public Program()
        {
            _loader = new StockLoader();
        }


        static async Task Main(string[] args)
        {

            var program = new Program();

            //if (args != null && args.Length > 0)
                await program.RunAsync();

            Environment.Exit(0);

        }

        public async Task RunAsync()
        {
            Console.WriteLine("Alert app started...");

            while (_run)
            {
                if (!CheckInputs())
                {
                    Console.WriteLine("Inputs are not valid. Try again");
                    _run = false;
                    break;

                }
                else
                    await _loader.CheckStockPrice(_stock, _inputPriceMin, _inputPriceMax);


                Console.WriteLine("Alert running...");
                await Task.Delay(5 * 1000 * 60);

            }

        }

        public bool CheckInputs()
        {
            try
            {
                var args = _argument.Split('_');

                if (!string.IsNullOrEmpty(args[0]) && args.Length == 3 
                    && Double.TryParse(args[1], out var minPrice) 
                    && Double.TryParse(args[2], out var maxPrice))
                {
                    if (minPrice > maxPrice || !minPrice.Equals(maxPrice))
                    {
                        _stock = args[0];
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
    }
}

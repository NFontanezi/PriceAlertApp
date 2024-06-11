using PriceAlertApp.Services.AlphaVantageApiServices;
using PriceAlertApp.Services.Mail;

namespace PriceAlertApp.Services.Stocks
{
    public class StockService : IStockService
    {
        private readonly IAlphaWebApiService _assetService;
        private readonly IMailService _mailService;

        public StockService(IAlphaWebApiService assetService, IMailService mailService)
        {
            _assetService = assetService;
            _mailService = mailService;
        }
        public async Task CheckStockPrice(string stockName, double inputPriceMin, double inputPriceMax)
        {
            var symbol = GetSymbol(stockName);
            var stockData = await _assetService.GetStockPrice(symbol);

            if (stockData == null)
                Console.WriteLine("Stock data not found");

            else
            {
                if (stockData.DailyCloses.Any())
                {
                    var actionSale = string.Empty;

                    if (stockData.DailyCloses.First().Close <= inputPriceMin)
                    {
                        actionSale = "BUY";
                        await _mailService.SendAlertEmail(stockData, actionSale, inputPriceMin);
                    }

                    if (stockData.DailyCloses.First().Close >= inputPriceMax)
                    {
                        actionSale = "SELL";
                        await _mailService.SendAlertEmail(stockData, actionSale, inputPriceMax);
                    }
                }

                else
                    Console.WriteLine("Price not available");
            }
        }

        private string GetSymbol(string stockName)
        {
            if (stockName.Contains("."))
                return stockName;

            else
                return stockName + ".SA";

        }
    }
}

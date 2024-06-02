
using PriceAlertApp.Services.AlphaVantageApiServices;

namespace PriceAlertApp.Services.Stocks
{
    public class StockService : IStockService
    {
        private readonly IAlphaWebApiExecutor _assetService;
        //private readonly IMailService _mailService;

        public StockService()
        {
            _assetService = new AlphaWebApiService();
            //  _mailService = new MailService();
        }
        public async Task CheckStockPrice(string stockName, double inputPriceMin, double inputPriceMax)
        {
            var symbol = GetSymbol(stockName);
            var stockData = await _assetService.GetStockPrice(symbol);
            if (stockData != null)
            {
                if (stockData.DailyCloses.Any())
                {
                    var actionSale = string.Empty;

                    if (stockData.DailyCloses.First().Close <= inputPriceMin)
                    {
                        actionSale = "BUY";
                        //  _mailService.SendMail(stock, actionSale);
                    }

                    if (stockData.DailyCloses.First().Close >= inputPriceMin)
                    {
                        actionSale = "SELL";
                        //  _mailService.SendMail(stock, actionSale);
                    }
                }
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

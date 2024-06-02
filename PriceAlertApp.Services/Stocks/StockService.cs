

using PriceAlertApp.Models;
using PriceAlertApp.Services.AlphaVantageApiServices;

namespace PriceAlertApp.Services.Stocks
{
    public class StockService : IStockService
    {
        private readonly IAssetPriceService _assetService;
        //private readonly IMailService _mailService;

        public StockService()
        {
            _assetService = new AssetPriceService();
            //  _mailService = new MailService();
        }
        public async Task CheckStockPrice(string stockName, double inputPriceMin, double inputPriceMax)
        {

            var stockPrice = await _assetService.GetCurrentPrice(stockName.ToUpper());
            var stock = new Stock();
            stock.Name = stockName.ToUpper();
            stock.Price = stockPrice;

            var actionSale = string.Empty;

            if (inputPriceMin.Equals(inputPriceMax))
                Console.WriteLine("Prices can not be evaluated. Min and Max inputs should be differents");

            if (stockPrice <= inputPriceMin)
            {
                actionSale = "BUY";
                //  _mailService.SendMail(stock, actionSale);
            }

            if (stockPrice >= inputPriceMin)
            {
                actionSale = "SELL";
                //  _mailService.SendMail(stock, actionSale);
            }
        }
    }
}

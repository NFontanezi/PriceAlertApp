


using PriceAlertApp.Models;
using PriceAlertApp.Services.AlphaVantageApiServices;

namespace PriceAlertApp.Services.Stocks
{
    public class StockLoader : IStockLoader
    {
        private readonly IAssetPriceService _assetService;
       // private readonly IMailService _mailService;

        public StockLoader() 
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

            if (stockPrice <= inputPriceMin)
                actionSale = "BUY";


            if (stockPrice >= inputPriceMin)
                actionSale = "SELL";

            //  _mailService.SendMail(stock, actionSale);
            await Task.Delay(1000);


        }

    }
}

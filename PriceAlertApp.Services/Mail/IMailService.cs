using PriceAlertApp.Models;

namespace AlertApp.Services.Mail
{
    public interface IMailService
    {
       Task SendAlertEmail(StockData stockData, string actionSale, double input);

    }
}

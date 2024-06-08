using PriceAlertApp.Models;

namespace PriceAlertApp.Services.Mail
{
    public interface IMailService
    {
       Task SendAlertEmail(StockData stockData, string actionSale, double input);

    }
}

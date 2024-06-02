
namespace PriceAlertApp.Services.Stocks
{
    public interface IStockService
    {
        Task CheckStockPrice(string stockName, double inputPriceMin, double inputPriceMax);
    }
}

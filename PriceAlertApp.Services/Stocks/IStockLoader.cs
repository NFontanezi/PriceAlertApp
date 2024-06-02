namespace PriceAlertApp.Services.Stocks
{
    public interface IStockLoader
    {
        Task CheckStockPrice(string stockName, double inputPriceMin, double inputPriceMax);
    }
}

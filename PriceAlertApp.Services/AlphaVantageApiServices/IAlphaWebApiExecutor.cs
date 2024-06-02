
using PriceAlertApp.Models;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public interface IAlphaWebApiExecutor
    {
        Task<StockData> GetStockPrice(string assetName);
    }
}


using PriceAlertApp.Models;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public interface IAlphaWebApiService
    {
        Task<StockData> GetStockPrice(string assetName);
    }
}

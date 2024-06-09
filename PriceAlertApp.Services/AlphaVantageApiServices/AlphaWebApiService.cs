

using PriceAlertApp.Models;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public class AlphaWebApiService : IAlphaWebApiService
    {
        private readonly IAlphaWebApiExecutor _alphaClient;

        public AlphaWebApiService(IAlphaWebApiExecutor alphaClient)
        {
            _alphaClient = alphaClient;
        }

        public async Task<StockData?> GetStockPrice(string symbol)
        {

            return await _alphaClient.InvokeGet<StockData?>(symbol);
        }

    }
}

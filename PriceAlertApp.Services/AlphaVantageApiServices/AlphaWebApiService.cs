

using PriceAlertApp.Models;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public class AlphaWebApiService : IAlphaWebApiExecutor
    {
        private readonly AlphaWebApiExecutor _alphaClient;

        public AlphaWebApiService()
        {
            _alphaClient = new AlphaWebApiExecutor();
        }

        public async Task<StockData?> GetStockPrice(string symbol)
        {

            return await _alphaClient.InvokeGet<StockData?>(symbol);
        }

    }
}

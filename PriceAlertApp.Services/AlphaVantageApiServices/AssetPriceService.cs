

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public class AssetPriceService : IAssetPriceService
    {
        private readonly AlphaVantageWebApi _alphaClient;

        public AssetPriceService()
        {
           // _alphaClient = new AlphaVantageWebApi();
        }

        public async Task<double> GetCurrentPrice(string assetName)
        { /* tbd
           * 
            var queryParams = $"stockName={stockName}";

            var requestUri = new Uri(
                uriString: $"xxx/stockName?{queryParams}",
                uriKind: UriKind.Relative);

            return await _alphaClient.InvokeGet<double>(requestUri.ToString());
            */

            return 0.0;
        }


    }
}

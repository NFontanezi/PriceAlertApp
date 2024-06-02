
namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public interface IAssetPriceService
    {
        Task<double> GetCurrentPrice(string assetName);
    }
}

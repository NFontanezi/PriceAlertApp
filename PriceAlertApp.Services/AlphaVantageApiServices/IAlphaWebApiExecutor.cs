
namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public interface IAlphaWebApiExecutor
    {
        Task<T> Get<T>(string symbol);
    }
}

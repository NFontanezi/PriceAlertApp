
namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public interface IAlphaWebApiExecutor
    {
        Task<T> InvokeGet<T>(string symbol);
    }
}

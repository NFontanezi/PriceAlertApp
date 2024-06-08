using Newtonsoft.Json.Linq;
using PriceAlertApp.Models;
using System.Net;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public class AlphaWebApiExecutor
    {
        private readonly string _baseUrl = @"https://www.alphavantage.co/";
        private readonly string _apiKey = "LH5K76VQPNWWGHDT";
        private readonly HttpClient _httpClient = new();

        public async Task<T> InvokeGet<T>(string symbol)
        {
            var path = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&interval=5min&apikey={_apiKey}";

            Uri queryUri = new Uri(path);

            string jsonString;

            try
            {
                using (WebClient client = new WebClient())
                {
                    jsonString = client.DownloadString(queryUri);
                }

                var stockData = ExtractStockData(jsonString);
                return (T)Convert.ChangeType(stockData, typeof(T));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebException occurred: {ex.GetType()}: {ex.Message}");
            }

            return default(T);
        }

        public static StockData ExtractStockData(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);

            var stockData = new StockData
            {
                Symbol = jsonObject["Meta Data"]["2. Symbol"].ToString()
            };

            var timeSeries = jsonObject["Time Series (Daily)"] as JObject;

            foreach (var item in timeSeries)
            {
                var date = DateTime.Parse(item.Key);
                var close = double.Parse(item.Value["4. close"].ToString());

                stockData.DailyCloses.Add(new DailyClose { Date = date, Close = close });
            }

            return stockData;


        }
    }
}

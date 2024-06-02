

using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace PriceAlertApp.Services.AlphaVantageApiServices
{
    public class AlphaVantageWebApi
    {
        private readonly string _baseUrl = "xxx";
        private readonly string _username = "xxx";
        private readonly string _password = "xxx";
        private readonly HttpClient _httpClient = new();

        public AlphaVantageWebApi()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.Timeout = TimeSpan.FromMilliseconds(600000);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var byteArray = Encoding.ASCII.GetBytes($"{_username}:{_password}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task<T> InvokeGet<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            HandleError(response);

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }


        private static void HandleError(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();

                if ((int)response.StatusCode == 207)
                {

                    Console.WriteLine("Warning - HttpRequest - some operations have failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()}: {ex.Message}");
            }

        }
    }
}

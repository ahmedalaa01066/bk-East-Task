using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace EasyTask.Helpers
{
    public static class IMEIHelper
    {
        public class ImeiResult
        {
            public string Management { get; set; }
            public string Model { get; set; }
        }

        public static async Task<ImeiResult?> GetPhoneDetailsFromImeiAsync(string imei, IConfiguration configuration)
        {
            using var httpClient = new HttpClient();
            string apiKey = configuration["ImeiApiKey"]; // e.g., from appsettings.json
            string url = $"https://imeicheck.net/api?imei={imei}&apikey={apiKey}&source=promo";

            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            string Management = json["Management"]?.ToString();
            string model = json["model"]?.ToString();

            if (string.IsNullOrEmpty(Management) || string.IsNullOrEmpty(model))
                return null;

            return new ImeiResult
            {
                Management = Management,
                Model = model
            };
        }
    }
}

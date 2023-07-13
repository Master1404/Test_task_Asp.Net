using Test_task_Asp.Net.Models;

namespace Test_task_Asp.Net.Core
{
    public class ApiService : IApiService
    {

        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.httpClient.BaseAddress = new Uri("https://api.coincap.io/v2/");
        }

        public async Task<IEnumerable<string>> GetCryptoCurrencies()
        {
            var response = await httpClient.GetFromJsonAsync<ApiResponse>("assets");
            return response?.Data?.Select(asset => asset.Symbol);
        }
    }
}

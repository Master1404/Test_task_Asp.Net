using System.Text;

namespace Test_task_Asp.Net.Core
{
    public class PairsProviderService : IPairsProvider
    {
        private readonly IApiService _apiService;

        public PairsProviderService(IApiService apiService) 
        {
           _apiService = apiService;
        }

        public async Task<uint> CountAsync()
        {
            var cryptoCurrencies = await _apiService.GetCryptoCurrencies();
            uint count = (uint)cryptoCurrencies.Count();
            uint pairsCount = (count * (count - 1)) / 2;
            return pairsCount;
        }

        public async Task<IEnumerable<string>> GetPairsAsync(int page)
        {
            var cryptoCurrencies = await _apiService.GetCryptoCurrencies();
            int pageSize = 20;
            int startIndex = (page - 1) * pageSize;
            List<string> pairs = new List<string>();
            int currenciesCount = cryptoCurrencies.Count();
            int pairsCount = pageSize;
            var combinations = GenerateCombinations(cryptoCurrencies, 2).ToList();

            if (startIndex >= combinations.Count)
            {
                return pairs;
            }

            if (startIndex + pageSize > combinations.Count)
            {
                pairsCount = combinations.Count - startIndex;
            }

            pairs.AddRange(combinations.Skip(startIndex).Take(pairsCount));

            return pairs;
        }

        private IEnumerable<string> GenerateCombinations(IEnumerable<string> elements, int length)
        {
            if (length == 1)
            {
                return elements;
            }

            return elements.SelectMany((element, index) =>
                GenerateCombinations(elements.Skip(index + 1), length - 1)
                    .Select(combination => element + "-" + combination)
            );
        }
    }
}

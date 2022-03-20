using CryptSwitch.ApiServices;

namespace CryptSwitch.Builders
{
    public class TradingModelBuilder
    {
        public async Task<string> LoadExchangeRates()
        {
            const string url = "https://api.coingecko.com/api/v3/exchange_rates";
            var result = "";

            using (HttpResponseMessage responese = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (responese.IsSuccessStatusCode)
                {
                    result = await responese.Content.ReadAsStringAsync();
                }
            }

            return result;
        }
    }
}

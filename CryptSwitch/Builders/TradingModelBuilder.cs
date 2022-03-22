using CryptSwitch.ApiServices;
using CryptSwitch.Models;
using Newtonsoft.Json;

namespace CryptSwitch.Builders
{
    public class TradingModelBuilder
    {
        
        public async Task<ExchangeResults> LoadExchangeRates()
        {
            const string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";
            

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStreamAsync(); 
                    var streamReader = new StreamReader(result);
                    var jsonReader = new JsonTextReader(streamReader);

                    JsonSerializer serializer = new JsonSerializer();

                    try
                    {
                        ExchangeResults exchange = serializer.Deserialize<ExchangeResults>(jsonReader);
                        return exchange;
                    }
                    catch (Exception ex)
                    {

                    }
                    //ExchangeResults results = await response.Content.ReadFromJsonAsync<ExchangeResults>();

                    return null;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }

            
        }
    }
}

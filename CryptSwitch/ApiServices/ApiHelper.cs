using System.Net.Http.Headers;

namespace CryptSwitch.ApiServices
{
    public static class ApiHelper
    {
        private static string API_KEY = "a7a2cb34-f925-4875-84c2-154937cbb70b";
        public static HttpClient ApiClient { get; set; } 

        public static void InitialiseClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", API_KEY);
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
    }
}

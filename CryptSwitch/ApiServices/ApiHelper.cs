using System.Net.Http.Headers;

namespace CryptSwitch.ApiServices
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } 

        public static void InitialiseClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

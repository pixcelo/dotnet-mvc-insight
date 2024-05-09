namespace Insight.Services
{
    public class InstagramApiClient : IInstagramApiClient
    {
        private readonly HttpClient _httpClient;        
        private string _accessToken;

        public InstagramApiClient(IHttpClientFactory httpClientFactory)
        {            
            _httpClient = httpClientFactory.CreateClient();
        }

        public void SetAccessToken(string accessToken)
        {
            _accessToken = accessToken;
        }
    }
}

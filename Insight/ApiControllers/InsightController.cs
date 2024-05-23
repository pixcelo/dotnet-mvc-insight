using Insight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insight.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsightController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;        
        private readonly IAccessTokenAccessor _accessTokenAccessor;

        public InsightController(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory, 
            IAccessTokenAccessor accessTokenAccessor)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();            
            _accessTokenAccessor = accessTokenAccessor;
        }

        [HttpGet]
        public async Task<string> GetInsight()
        {
            try
            {
                var accessToken = _accessTokenAccessor.GetAccessToken();
                //var accessToken = _configuration.GetSection("Authentication:Facebook:AccessToken").Value;

                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new ArgumentNullException("Access token is not set.");
                }

                var base_url = "https://graph.facebook.com";
                var id = "";
                var version = "v19.0";
                var endpoint = "insights?metric=impressions,reach,profile_views&period=day";
                var requestUri = $@"{base_url}/{version}/{id}/{endpoint}&access_token={accessToken}";

                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

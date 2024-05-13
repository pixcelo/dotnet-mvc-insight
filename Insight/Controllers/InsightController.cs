using Insight.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsightController : ControllerBase
    {
        private readonly HttpClient _httpClient;        
        private readonly IAccessTokenAccessor _accessTokenAccessor;

        public InsightController(
            IHttpClientFactory httpClientFactory, 
            IAccessTokenAccessor accessTokenAccessor)
        {
            _httpClient = httpClientFactory.CreateClient();            
            _accessTokenAccessor = accessTokenAccessor;
        }

        [HttpGet]
        public async Task<string> GetInsight()
        {
            try
            {                
                var accessToken = _accessTokenAccessor.GetAccessToken();

                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new ArgumentNullException("Access token is not set.");
                }
                
                var requestUri = "";

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

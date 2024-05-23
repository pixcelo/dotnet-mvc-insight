using InsightDDD.Models;
using InsightDDD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InsightDDD.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IAccessTokenAccessor _accessTokenAccessor;

        public MediaController(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IAccessTokenAccessor accessTokenAccessor)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _accessTokenAccessor = accessTokenAccessor;
        }

        [HttpGet]
        public async Task<List<MediaDetail>> GetMedia()
        {
            try
            {
                //var accessToken = _accessTokenAccessor.GetAccessToken();
                var accessToken = _configuration.GetSection("Authentication:Facebook:AccessToken").Value;

                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new ArgumentNullException("Access token is not set.");
                }

                var base_url = "https://graph.facebook.com";
                var id = _configuration.GetSection("Authentication:Facebook:UserId").Value;
                var version = "v19.0";
                var endpoint = "media?";
                var requestUri = $@"{base_url}/{version}/{id}/{endpoint}&access_token={accessToken}";

                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                var mediaData = JsonSerializer.Deserialize<MediaResponse>(responseContent);

                var mediaDetails = new List<MediaDetail>();

                foreach (var data in mediaData.dataList)
                {
                    var mediaDetail = await GetMediaDetail(data.id);
                    if (mediaDetail != null)
                    {
                        mediaDetails.Add(mediaDetail);
                    }
                }

                return mediaDetails;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MediaDetail>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MediaDetail>();
            }
        }

        private async Task<MediaDetail?> GetMediaDetail(string mediaId)
        {
            try
            {                
                var accessToken = _configuration.GetSection("Authentication:Facebook:AccessToken").Value;
                var base_url = "https://graph.facebook.com";                
                var version = "v19.0";
                var endpoint = "fields=caption,like_count,media_url";
                var requestUri = $@"{base_url}/{version}/{mediaId}?{endpoint}&access_token={accessToken}";

                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                var mediaDetail = JsonSerializer.Deserialize<MediaDetail>(responseContent);

                return mediaDetail;
            }
            catch (HttpRequestException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
    }
}

using Insight.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    public class InsightController : Controller
    {
        private readonly IInstagramApiClient _instagramApiClient;

        public InsightController(IInstagramApiClient instagramApiClient)
        {            
            _instagramApiClient = instagramApiClient;
        }

        [Authorize]
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AccessToken"))
            {
                var accessToken = TempData["AccessToken"] as string;
                _instagramApiClient.SetAccessToken(accessToken);
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    public class InsightController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (TempData.ContainsKey("AccessToken"))
            {
                var accessToken = TempData["AccessToken"] as string;                
            }

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

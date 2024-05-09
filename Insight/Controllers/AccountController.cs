
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var prop = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(LoginCallback))
            };

            return Challenge(prop);
        }

        public async Task<IActionResult> LoginCallback()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            if (result?.Succeeded != true)
            {
                // ログイン失敗
                return RedirectToAction("Index", "Home");
            }

            var accessToken = result.Properties.GetTokenValue("access_token");

            // アクセストークンを一時的に保存
            TempData["AccessToken"] = accessToken;

            return RedirectToAction("Index", "Insight");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

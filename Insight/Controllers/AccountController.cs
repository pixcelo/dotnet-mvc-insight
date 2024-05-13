
using Insight.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Insight.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAccessTokenAccessor _accessTokenAccessor;

        public AccountController(IAccessTokenAccessor accessTokenAccessor)
        {
            _accessTokenAccessor = accessTokenAccessor;
        }

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

            // アクセストークンを一時的に保存
            var accessToken = result.Properties.GetTokenValue("access_token");
            _accessTokenAccessor.SetAccessToken(accessToken);

            return RedirectToAction("Index", "Board");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}

using InsightDDD.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InsightDDD.Services;

namespace InsightDDD.Controllers
{
    public class HomeController : Controller
    {        
        public HomeController(IAccessTokenAccessor accessTokenAccessor)
        {
            _accessTokenAccessor = accessTokenAccessor;
        }

        private readonly IAccessTokenAccessor _accessTokenAccessor;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                // ���O�C�����s
                return RedirectToAction(nameof(Index), "Home");
            }

            // �A�N�Z�X�g�[�N�����ꎞ�I�ɕۑ�
            var accessToken = result?.Properties?.GetTokenValue("access_token");
            _accessTokenAccessor.SetAccessToken(accessToken);

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index), "Home");
        }

        
    }
}

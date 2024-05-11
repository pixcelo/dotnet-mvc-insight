using Insight.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InsightTests.ControllersTests
{
    public class HomeControllerTest
    {
        // return View("Index")のように明示的に宣言しないとテストは失敗する
        [Fact(DisplayName = "Index画面を返すテスト ")]

        public void TestIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.Equal("Index", result.ViewName);
        }
    }
}
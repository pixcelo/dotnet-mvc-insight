using Insight.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InsightTests.ControllersTests
{
    public class HomeControllerTest
    {
        // return View("Index")�̂悤�ɖ����I�ɐ錾���Ȃ��ƃe�X�g�͎��s����
        [Fact(DisplayName = "Index��ʂ�Ԃ��e�X�g ")]

        public void TestIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.Equal("Index", result.ViewName);
        }
    }
}
namespace ConsoleWebServer.Tests
{
    using ConsoleWebServer.Application.Controllers;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult.JsonActionResult;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApiControllerTests
    {
        [TestMethod]
        public void ApiControllerShourReturnShouldReturnParameter()
        {
            var requestMethod = "GET";
            var uri = "/ReturnMe/someparam";
            var expected = @"{""param"":""someparam""}";
            var param = "someparam";
            var httpVersion = "HTTP/1.1";
            var httpRequest = new HttpRequest(requestMethod, uri, httpVersion);
            var apiController = new ApiController(httpRequest);
            Assert.AreEqual(expected, apiController.ReturnMe(param));
        }
    }
}

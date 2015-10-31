namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;

    using ConsoleWebServer.Application.Controllers;
    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult.Contracts;
    using ConsoleWebServer.Framework.ActionResult.JsonActionResult;

    using global::ConsoleWebServer.Framework.ResponseProvider;

    using Newtonsoft.Json;

    public static class Startup
    {
        public static void Main()
        {
            var exprectedParameter = "someparam";

            var requestMethod = "GET";
            var uri = "Api/ReturnMe/" + exprectedParameter;

            var httpVersion = "HTTP/1.1";
            var httpRequest = new HttpRequest(requestMethod, uri, httpVersion);

            IActionResult param = new JsonActionResult(httpRequest, exprectedParameter);
            var expected = JsonConvert.SerializeObject(param);
            var apiController = new ApiController(httpRequest);
            Console.WriteLine(expected);
            Console.WriteLine(JsonConvert.DeserializeObject(apiController.ReturnMe(exprectedParameter).ToString()));

            //Start();
        }

        public static void Start()
        {
            ResponseProvider responseProvider  = new ResponseProvider();
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                var response = responseProvider.GetResponse(inputLine);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(response);
                Console.ResetColor();
                requestBuilder.Clear();
                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}

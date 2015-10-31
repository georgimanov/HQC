namespace ConsoleWebServer.Framework.ActionResult.JsonActionResult
{
    using System.Net;

    using ConsoleWebServer.Framework;
    using ConsoleWebServer.Framework.ActionResult.Contracts;
    using ConsoleWebServer.Framework.ResponseProvider;

    using Newtonsoft.Json;

    public class JsonActionResult : BaseActionResult, IActionResult
    {
        public JsonActionResult(HttpRequest httpRequest, object model)
            : base(httpRequest, model)
        {
        }

        protected override HttpResponse GenerateResponse()
        {
            return new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, JsonConvert.SerializeObject(this.Model), "application/json");
        }
    }
}
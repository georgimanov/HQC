namespace ConsoleWebServer.Framework.ActionResult.ContentActionResult
{
    using System.Net;

    using ConsoleWebServer.Framework.ActionResult.Contracts;
    using ConsoleWebServer.Framework.ResponseProvider;

    public class ContentActionResult : BaseActionResult, IActionResult
    {
        public ContentActionResult(HttpRequest httpRequest, object model)
            : base(httpRequest, model)
        {
        }

        protected override HttpResponse GenerateResponse()
        {
            return new HttpResponse(
               this.Request.ProtocolVersion,
               HttpStatusCode.OK,
               this.Model.ToString(),
               "text/plain; charset=utf-8");
        }
    }
}

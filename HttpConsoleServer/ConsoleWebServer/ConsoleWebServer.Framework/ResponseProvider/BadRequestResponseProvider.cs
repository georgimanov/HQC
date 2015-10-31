namespace ConsoleWebServer.Framework.ResponseProvider
{
    using System.Net;

    internal class BadRequestResponseProvider : BaseResponseProvider
    {
        public override HttpResponse GetResponse(HttpRequest request)
        {
            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, "Request cannot be handled.");
        }
    }
}

namespace ConsoleWebServer.Framework.ResponseProvider
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class StaticFileHandler : BaseResponseProvider
    {
        public StaticFileHandler()
        {
            this.Successor = new ControllerResponseProvider();
        }

        public bool CanHandle(HttpRequest request)
        {
            return request.Uri.LastIndexOf(".", StringComparison.Ordinal)
                   > request.Uri.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string fileWholePath = Environment.CurrentDirectory + "/" + request.Uri;

            if (File.Exists(fileWholePath))
            {
                string fileContents = File.ReadAllText(fileWholePath);
        
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            }

            return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
        }

        public override HttpResponse GetResponse(HttpRequest request)
        {
            if (new StaticFileHandler().CanHandle(request))
            {
                return new StaticFileHandler().Handle(request);
            }

            return this.Successor.GetResponse(request);
        }
    }
}
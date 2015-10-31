namespace ConsoleWebServer.Framework.ResponseProvider
{
    using System;
    using System.Net;

    public class ResponseProvider : BaseResponseProvider
    {
        public ResponseProvider()
        {
            this.Successor = new OptionsResponseProvider();
        }

        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                var requestParser = new HttpRequest("GET", "/", "1.1");
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                return new HttpResponse(new Version(1, 1), HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(request);

            return response;
        }

        public override HttpResponse GetResponse(HttpRequest request)
        {
            if (request.Method.ToLower() == "head")
            {
                return new HttpResponse(
                    request.ProtocolVersion,
                    HttpStatusCode.OK,
                    string.Empty);
            }

            return this.Successor.GetResponse(request);
        }

        private HttpResponse Process(HttpRequest request)
        {
            return this.GetResponse(request);
        }
    }
}
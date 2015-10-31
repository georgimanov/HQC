namespace ConsoleWebServer.Framework.ActionResult
{
    using System.Collections.Generic;

    using ConsoleWebServer.Framework.ActionResult.Contracts;
    using ConsoleWebServer.Framework.ResponseProvider;

    public abstract class BaseActionResult : IActionResult
    {
        public readonly object Model;

        protected BaseActionResult(HttpRequest httpRequest, object model)
        {
            this.Model = model;
            this.Request = httpRequest;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public virtual HttpResponse GetResponse()
        {
            var response = this.GenerateResponse();
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }

        protected abstract HttpResponse GenerateResponse();
    }
}

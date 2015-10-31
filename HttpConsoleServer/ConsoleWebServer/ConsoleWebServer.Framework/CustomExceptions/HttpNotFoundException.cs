namespace ConsoleWebServer.Framework.CustomExceptions
{
    using System;

    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException(string message) : base(message)
        {
        }
    }
}
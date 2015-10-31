namespace ConsoleWebServer.Framework.ResponseProvider
{
    public abstract class BaseResponseProvider
    {
        protected BaseResponseProvider Successor { get; set; }

        public void SetSuccessor(BaseResponseProvider successor)
        {
            this.Successor = successor;
        }

        public abstract HttpResponse GetResponse(HttpRequest requestAsString);
    }
}

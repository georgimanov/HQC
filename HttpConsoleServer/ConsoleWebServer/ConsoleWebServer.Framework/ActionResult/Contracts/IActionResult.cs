namespace ConsoleWebServer.Framework.ActionResult.Contracts
{
    using ConsoleWebServer.Framework.ResponseProvider;

    /// <summary>
    ///     Interface for action results
    /// </summary>
    public interface IActionResult
    {
        /// <summary>
        ///     Provides the HTTP response
        /// </summary>
        /// <returns>Http response</returns>
        HttpResponse GetResponse();
    }
}
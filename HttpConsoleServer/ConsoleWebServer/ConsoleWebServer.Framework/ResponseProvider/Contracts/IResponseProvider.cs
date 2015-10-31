namespace ConsoleWebServer.Framework.ResponseProvider.Contracts
{
    /// <summary>
    ///     Inferface for response provider
    /// </summary>
    public interface IResponseProvider
    {
        /// <summary>
        ///     Returns response based on provided request as string
        /// </summary>
        /// <param name="requestAsString">Provided string</param>
        /// <returns>The Http response</returns>
        HttpResponse GetResponse(string requestAsString);
    }
}

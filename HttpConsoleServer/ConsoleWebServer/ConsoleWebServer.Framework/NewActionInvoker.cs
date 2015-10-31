namespace ConsoleWebServer.Framework
{
    using ConsoleWebServer.Framework.ActionResult.Contracts;
    using ConsoleWebServer.Framework.CustomExceptions;

    internal class NewActionInvoker
    {
        public IActionResult InvokeAction(Controller controller, ActionDescriptor actionDescriptor)
        {
            //// TODO: remove not used?
            ////var className = HttpNotFoundException.ClassName;
            return new ActionInvoker().InvokeAction(controller, actionDescriptor);
        }
    }
}
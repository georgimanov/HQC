namespace ConsoleWebServer.Framework.ResponseProvider
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    using ConsoleWebServer.Framework.CustomExceptions;

    public class ControllerResponseProvider : BaseResponseProvider
    {
        public ControllerResponseProvider()
        {
            this.Successor = new BadRequestResponseProvider();
        }
                
        public override HttpResponse GetResponse(HttpRequest request)
        {
            if (request.ProtocolVersion.Major < 3)
            {
                HttpResponse response;
                try
                {
                    var controller = this.CreateController(request);
                    var actionInvoker = new NewActionInvoker();
                    var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                    response = actionResult.GetResponse();
                }
                catch (HttpNotFoundException exception)
                {
                    response = new HttpResponse(
                        request.ProtocolVersion,
                        HttpStatusCode.NotFound,
                        exception.Message);
                }
                catch (Exception exception)
                {
                    response = new HttpResponse(
                        request.ProtocolVersion,
                        HttpStatusCode.InternalServerError,
                        exception.Message);
                }

                return response;
            }

            return this.Successor.GetResponse(request);
        }

        private Controller CreateController(HttpRequest request)
        {
            var controllerClassName = request.Action.ControllerName + "Controller";

            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(
                        x =>
                            x.Name.ToLower() == controllerClassName.ToLower() &&
                            typeof(Controller).IsAssignableFrom(x));
            if (type == null)
            {
                throw new HttpNotFoundException(
                    string.Format("Controller with name {0} not found!", controllerClassName));
            }

            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}

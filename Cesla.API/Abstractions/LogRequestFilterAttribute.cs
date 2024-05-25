using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Cesla.API.Abstractions
{
    public class LogRequestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Aqui você pode acessar informações sobre o request, como o caminho, método HTTP, etc.
            var requestPath = context.HttpContext.Request.Path;
            var httpMethod = context.HttpContext.Request.Method;
            var controllerName = context.Controller.ToString();

            // Code before the action method is executed

            Log.Information($"----------------- Iniciando controller {controllerName} -----------------");
            Log.Information($"Request Path: {requestPath}, Method: {httpMethod}");

            if (context.Exception != null)
            {
                Log.Error(context.Exception, "Exception ocurred: -> {Message} -> {@Exception}",
                                  context.Exception.Message,
                                  context.Exception);

                // Handle the exception as needed, log it, and return an appropriate response.
                context.Result = new ObjectResult("An error occurred")
                {
                    StatusCode = 500
                };

                // Mark the exception as handled
                context.ExceptionHandled = true;
            }
        }
    }
}

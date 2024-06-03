using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectManager.Filters;

public class NotFoundFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();

        if (resultContext.Result is ObjectResult objectResult && objectResult.Value == null)
        {
            resultContext.Result = new NotFoundObjectResult(new { Message = "Resource not found" });
        }
    }
}

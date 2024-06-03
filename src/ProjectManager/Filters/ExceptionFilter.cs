using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ArgumentException)
        {
            context.Result = new BadRequestObjectResult(new { Message = context.Exception.Message });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is InvalidOperationException)
        {
            context.Result = new NotFoundObjectResult(new { Message = context.Exception.Message });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new { Message = "An unexpected error occurred." })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Exceptions;

namespace ProjectManager.Filters;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(ProjectNotExistException),  HandleNotExistException },
            {typeof(ProjectDontHaveDesignObjectsException),  HandleProjectDontHaveDesignObjectsException },
            {typeof(DesignObjectNotExistException), HandleNotExistException }
        };
    }

    public Task OnExceptionAsync(ExceptionContext context)
    {
        HandleException(context);

        return Task.CompletedTask;
    }
    
    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        HandleNotImplementedException(context);
        return;
    }

    private void HandleNotExistException(ExceptionContext context)
    {
        _logger.LogWarning(context.Exception, "Resource not found: {Message}", context.Exception.Message);
        context.Result = new ObjectResult(new { Message = context.Exception.Message })
        {
            StatusCode = 404
        };

        context.ExceptionHandled = true;
    }

    private void HandleProjectDontHaveDesignObjectsException(ExceptionContext context)
    {
        _logger.LogWarning(context.Exception, "Project does not have design objects: {Message}", context.Exception.Message);
        context.Result = new ObjectResult(new { })
        {
            StatusCode = 404
        };

        context.ExceptionHandled = true;
    }

    private void HandleNotImplementedException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unexpected error occurred.");
        context.Result = new ObjectResult(new { Message = "An unexpected error occurred." })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}

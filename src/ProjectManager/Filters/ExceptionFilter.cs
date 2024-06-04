using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Exceptions;

namespace ProjectManager.Filters;

public class ExceptionFilter : IAsyncExceptionFilter
{
    private readonly Dictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(ProjectNotExistException), HandleProjectNotExistException },
            {typeof(ProjectDontHaveDesignObjectsException),  HandleProjectDontHaveDesignObjectsException },
            {typeof(DesignObjectNotExistException), HandleDesignObjectNotExistException }
        };
    }

    private void HandleDesignObjectNotExistException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { Message = context.Exception.Message })
        {
            StatusCode = 404
        };
        context.ExceptionHandled = true;
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
    private void HandleProjectNotExistException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { Message = context.Exception.Message })
        {
            StatusCode = 404
        };
        context.ExceptionHandled = true;
    }

    private void HandleProjectDontHaveDesignObjectsException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { })
        {
            StatusCode = 200
        };
        context.ExceptionHandled = true;
    }
    private void HandleNotImplementedException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { Message = "An unexpected error occurred." })
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
}

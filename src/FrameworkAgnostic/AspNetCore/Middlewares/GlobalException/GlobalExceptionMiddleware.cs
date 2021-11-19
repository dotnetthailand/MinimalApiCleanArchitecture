namespace FrameworkAgnostic.AspNetCore.Middlewares;

using FrameworkAgnostic.AspNetCore.Middlewares.GlobalException;
using System.Net;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IExceptionHandlerLocator _exceptionHandlerLocator;

    public GlobalExceptionMiddleware(
        RequestDelegate next, 
        IExceptionHandlerLocator exceptionHandlerLocator)
    {
        _next = next;
        _exceptionHandlerLocator = exceptionHandlerLocator;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            var exceptionHandler = _exceptionHandlerLocator.GetExceptionHandler(exception.GetType());                    
            if(exceptionHandler is not null)
            {
                await exceptionHandler.HandleException(exception, response);
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync("An error occurred!!");
            }           
        }
    }
}


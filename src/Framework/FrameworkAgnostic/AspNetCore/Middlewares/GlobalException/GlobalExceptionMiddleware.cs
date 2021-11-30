namespace FrameworkAgnostic.AspNetCore.Middlewares;

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
            if (exceptionHandler is not null)
            {

                var exceptionInfo = await exceptionHandler.HandleException(exception);
                response.StatusCode = exceptionInfo.StatusCode;
                response.ContentType = "application/json";
                await response.WriteAsync(JsonSerializer.Serialize(exceptionInfo.Problem));
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsync("An error occurred!!");
            }
        }
    }
}


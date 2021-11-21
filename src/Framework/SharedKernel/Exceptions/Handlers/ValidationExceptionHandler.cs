namespace SharedKernel.Exceptions.Handlers;

[RegisterSingleton(For = typeof(IExceptionHandler), OfCollection = true)]
public class ValidationExceptionHandler : AbstractExceptionHandler<ValidationException>
{
    protected override async Task HandleExceptionInternal(ValidationException exception, HttpResponse httpResponse)
    {
        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };
        httpResponse.StatusCode = exception.StatusCode;
        httpResponse.ContentType = "application/json";
        await httpResponse.WriteAsync(JsonSerializer.Serialize(details));
    }
}


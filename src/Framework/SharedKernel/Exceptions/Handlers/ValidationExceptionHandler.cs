namespace SharedKernel.Exceptions.Handlers;

[RegisterSingleton(For = typeof(IExceptionHandler), OfCollection = true)]
public class ValidationExceptionHandler : AbstractExceptionHandler<ValidationException>
{
    protected override Task<(object Problem,int StatusCode)> HandleExceptionInternal(ValidationException exception)
    {
        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };
        return Task.FromResult((details as object, exception.StatusCode));
    }
}


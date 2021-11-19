namespace FrameworkAgnostic.Common.Exceptions.Handlers;
public interface IExceptionHandler {
    Task HandleException(Exception exception, HttpResponse httpResponse);
}
public interface IExceptionHandler<TException> : IExceptionHandler
{
    Task HandleException(TException exception, HttpResponse httpResponse);
}


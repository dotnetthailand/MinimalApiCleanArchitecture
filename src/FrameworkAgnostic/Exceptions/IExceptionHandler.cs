namespace Framework.Exceptions.Handlers;

public interface IExceptionHandler
{
    Task<(object Problem, int StatusCode)> HandleException(Exception exception);
}
public interface IExceptionHandler<TException> : IExceptionHandler
{
    Task<(object Problem, int StatusCode)> HandleException(TException exception);
}


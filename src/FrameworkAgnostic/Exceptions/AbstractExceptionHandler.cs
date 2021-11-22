namespace Framework.Exceptions.Handlers;

public abstract class AbstractExceptionHandler<T> : IExceptionHandler<T>
    where T : Exception
{
    public async Task<(object Problem, int StatusCode)> HandleException(Exception exception) => await HandleExceptionInternal((T)exception);
    public async Task<(object Problem, int StatusCode)> HandleException(T exception) => await HandleExceptionInternal(exception);
    protected abstract Task<(object Problem, int StatusCode)> HandleExceptionInternal(T exception);
}


namespace Framework.Exceptions.Handlers;

public abstract class AbstractExceptionHandler<T> : IExceptionHandler<T> where T : Exception
{
    public async Task HandleException(Exception exception, HttpResponse httpResponse) => await HandleExceptionInternal((T)exception, httpResponse);
    public async Task HandleException(T exception, HttpResponse httpResponse) =>  await HandleExceptionInternal(exception, httpResponse);
    protected abstract Task HandleExceptionInternal(T exception, HttpResponse httpResponse);
}


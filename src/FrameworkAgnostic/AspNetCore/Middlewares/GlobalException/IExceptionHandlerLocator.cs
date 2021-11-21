namespace FrameworkAgnostic.AspNetCore.Middlewares.GlobalException;

public interface IExceptionHandlerLocator
{
    IExceptionHandler GetExceptionHandler<T>();
    IExceptionHandler GetExceptionHandler(Type type);
}


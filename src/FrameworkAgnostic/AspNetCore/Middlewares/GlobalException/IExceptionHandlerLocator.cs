namespace FrameworkAgnostic.AspNetCore.Middlewares.GlobalException;

using FrameworkAgnostic.Common.Exceptions.Handlers;

public interface IExceptionHandlerLocator
{
    IExceptionHandler GetExceptionHandler<T>();
    IExceptionHandler GetExceptionHandler(Type type);
}


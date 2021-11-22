namespace FrameworkAgnostic.AspNetCore.Middlewares.GlobalException;

[RegisterSingleton]
public class DefaultExceptionHandlerLocator : IExceptionHandlerLocator
{
    private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;
    private readonly ConcurrentDictionary<Type, IExceptionHandler> _foundExceptionHandler = new();

    public DefaultExceptionHandlerLocator(IEnumerable<IExceptionHandler> exceptionHandlers) => _exceptionHandlers = exceptionHandlers;
    public IExceptionHandler GetExceptionHandler<TException>() => this.GetExceptionHandler(typeof(TException));
    public IExceptionHandler GetExceptionHandler(Type type) => this._foundExceptionHandler.GetOrAdd(type, this.FindExceptionHandler);
    private IExceptionHandler FindExceptionHandler(Type type)
    {
        var fullType = CreateExceptionHandlerType(type);

        var available = _exceptionHandlers
            .Where(handler => fullType.GetTypeInfo().IsInstanceOfType(handler))
            .ToArray();
        if (available.Length > 1)
        {
            var names = string.Join(", ", available.Select(v => v.GetType().Name));
            var message = string.Concat(
                "Ambiguous choice between multiple handlers for type ",
                type.Name,
                ". The handlers available are: ",
                names);

            throw new InvalidOperationException(message);
        }
        return available.FirstOrDefault();
    }
    private static Type CreateExceptionHandlerType(Type type) => typeof(AbstractExceptionHandler<>).MakeGenericType(type);

}


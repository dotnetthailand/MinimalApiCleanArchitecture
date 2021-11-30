namespace FrameworkAgnostic;

public interface IValidatorLocator
{
    IValidator GetValidator<T>();
    IValidator GetValidator(Type type);
}

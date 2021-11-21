namespace Microsoft.AspNetCore.Http;

public static class ValidationExtensions
{
    public static ValidationResult Validate<T>(this T model, IValidatorLocator validatorLocator) where T : class
    {       
        _ = validatorLocator ?? throw new ArgumentNullException(nameof(validatorLocator));

        var validator = validatorLocator!.GetValidator<T>();
        _ = validator ?? throw new InvalidOperationException($"Cannot find validator for model of type '{typeof(T).Name}'");

        return validator.Validate(new ValidationContext<T>(model));
    }

    public static ValidationResult Validate<T>(this HttpRequest request, T model)
    {
        var validatorLocator = request.HttpContext.RequestServices.GetService<IValidatorLocator>();
        _ = validatorLocator ?? throw new ArgumentNullException(nameof(validatorLocator));
        
        var validator = validatorLocator!.GetValidator<T>();
        _ = validator ?? throw new InvalidOperationException($"Cannot find validator for model of type '{typeof(T).Name}'");

        return validator.Validate(new ValidationContext<T>(model));
    }

    public static Dictionary<string, string[]> ToValidationProblems(this ValidationResult result) =>
        result.Errors
           .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
           .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

}
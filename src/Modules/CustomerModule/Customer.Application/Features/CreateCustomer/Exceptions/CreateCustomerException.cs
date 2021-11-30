namespace Customer.Application.Features.CreateCustomer.Exceptions;

public class CreateCustomerException : Exception
{
    public string AdditionalInfo { get; set; }
    public string Type { get; set; }
    public string Detail { get; set; }
    public string Title { get; set; }
    public string Instance { get; set; }
    public string DomainErrorCode { get; set; }
    public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;

    public CreateCustomerException(string instance, Exception? innerException = null)
        : base("There was an unexpected error while creating the customer.", innerException)
    {
        Type = "customer-custom-exception";
        Detail = "There was an unexpected error while creating the customer.";
        Title = "Customer Module Exception";
        AdditionalInfo = "Maybe you can try again in a bit?";
        Instance = instance;
        DomainErrorCode = ApplicaionErrorCode.CannotCreateNewCustomer;
    }

}

public class CreateCustomerProblemDetails : ProblemDetails
{
    public string? AdditionalInfo { get; set; }
    public string? DomainErrorCode { get; set; }
}

[RegisterSingleton(For = typeof(IExceptionHandler), OfCollection = true)]
public class CreateCustomerExceptionHandler : AbstractExceptionHandler<CreateCustomerException>
{
    protected override Task<(object Problem, int StatusCode)> HandleExceptionInternal(CreateCustomerException exception)
    {
        CreateCustomerProblemDetails problemDetails = new()
        {
            Title = exception.Title,
            Detail = exception.Detail,
            Status = exception.StatusCode,
            Type = exception.Type,
            Instance = exception.Instance,
            AdditionalInfo = exception.AdditionalInfo,
            DomainErrorCode = exception.DomainErrorCode
        };        
        return Task.FromResult((problemDetails as object, exception.StatusCode));
    }
}

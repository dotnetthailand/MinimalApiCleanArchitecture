namespace Customer.Application.Features.CreateCustomer.Validation;

[RegisterSingleton(For = typeof(IValidator),OfCollection = true)]
public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(q => q.FirstName).NotNull().NotEmpty();
        RuleFor(q => q.LastName).NotNull().NotEmpty();
    }

}

namespace Customer.Application.Features.CreateCustomer.Validation;

using Agoda.IoC.Core;
using Customer.Application.Features.CreateCustomer.Dto;
using FluentValidation;


[RegisterSingleton(For = typeof(IValidator),OfCollection = true)]
public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerDtoValidator()
    {
        RuleFor(q => q.FirstName).NotNull().NotEmpty();
        RuleFor(q => q.LastName).NotNull().NotEmpty();
    }

}

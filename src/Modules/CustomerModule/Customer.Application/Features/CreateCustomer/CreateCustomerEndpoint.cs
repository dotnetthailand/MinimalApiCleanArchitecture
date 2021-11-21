namespace Customer.Application.Features.CreateCustomer;

using Customer.Application.Features.CreateCustomer.Dto;
using Customer.Application.Repositories;
using FrameworkAgnostic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Exceptions;

public class CreateCustomerEndpoint
{
    //Endpoint
    public static async Task<CreateCustomerResponse> CreateNewCustomer([FromBody]CreateCustomerRequest customerDto, IValidatorLocator validatorLocator, IMapper mapper, ICustomerRepository customerRepository, CancellationToken cancellationToken)
    {
        var result = customerDto.Validate(validatorLocator);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var customer = mapper.Map<Core.Entities.Customer>(customerDto);
        Core.Entities.Customer? record = null;
        try
        {
            record =  await customerRepository.CreateCustomerAsync(customer, cancellationToken);       
        }
        catch
        {
            // TODO: Add new custom exception
           
        }
        return mapper.Map<CreateCustomerResponse>(customer);
    }


}

namespace Customer.Application.Features.CreateCustomer;

public class CreateCustomerEndpoint
{
    /// <summary>
    /// Endpoint for customer creation
    /// </summary>
    /// <param name="customerDto"></param>
    /// <param name="validatorLocator"></param>
    /// <param name="mapper"></param>
    /// <param name="customerRepository"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>CreateCustomerResponse</returns>
    /// <exception cref="ValidationException"></exception>
    public static async Task<CreateCustomerResponse> CreateNewCustomer(
        [FromBody]CreateCustomerRequest customerDto, 
        IValidatorLocator validatorLocator, 
        IMapper mapper, 
        ICustomerRepository customerRepository, 
        CancellationToken cancellationToken)
    {
        var result = validatorLocator.Validate(customerDto);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
        // simulate error
        if (customerDto.FirstName.Contains("error")) throw new CreateCustomerException("CreateNewCustomer");
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

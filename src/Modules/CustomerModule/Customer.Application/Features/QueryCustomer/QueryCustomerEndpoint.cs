using Customer.Application.Features.QueryCustomer.Dto;

namespace Customer.Application.Features.QueryCustomer;

public class QueryCustomerEndpoint
{
    public static async Task<IResult> QueryCustomer(
      int id,     
      IMapper mapper,
      ICustomerRepository customerRepository,
      CancellationToken cancellationToken)
    {
        var customer = await customerRepository.QueryCustomerByIdAsync(id);
        return customer is null ? 
                Results.NotFound() : 
                Results.Ok(mapper.Map<QueryCustomerResponse>(customer));
    }
}

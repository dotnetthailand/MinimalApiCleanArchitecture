using Customer.Application.Features.QueryCustomerOrder.Dto;

namespace Customer.Application.Features.QueryCustomerOrder;

public  class QueryCustomerOrderEndpoint
{
    public static async Task<IResult> QueryCustomerOrder(
      int id,
      int orderId,
      IMapper mapper,
      ICustomerRepository customerRepository,
      CancellationToken cancellationToken)
    {
        var customerWithOrder = await customerRepository.QueryCustomerOrderAsync(id, orderId, cancellationToken);
        return customerWithOrder is null ?
                Results.NotFound() :
                Results.Ok(mapper.Map<QueryCustomerOrderResponse>(customerWithOrder));
    }
}

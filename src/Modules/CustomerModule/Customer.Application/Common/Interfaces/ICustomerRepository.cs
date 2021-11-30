namespace Customer.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task<Core.Entities.Customer?> CreateCustomerAsync(Core.Entities.Customer? customer, CancellationToken cancellationToken = default);
    Task<Core.Entities.Customer?> QueryCustomerByIdAsync(long? id, CancellationToken cancellationToken = default);
    Task<Core.Entities.Customer?> QueryCustomerOrderAsync(long? id,long? orderId, CancellationToken cancellationToken = default);
}

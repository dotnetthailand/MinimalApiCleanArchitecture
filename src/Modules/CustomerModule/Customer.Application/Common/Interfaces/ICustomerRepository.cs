namespace Customer.Application.Common.Interfaces;

public interface ICustomerRepository
{
    Task<Core.Entities.Customer> CreateCustomerAsync(Core.Entities.Customer customer, CancellationToken cancellationToken = default);
}

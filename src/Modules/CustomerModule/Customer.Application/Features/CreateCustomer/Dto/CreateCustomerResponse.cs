namespace Customer.Application.Features.CreateCustomer.Dto;

public class CreateCustomerResponse : IMapFrom<Core.Entities.Customer>
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }

}

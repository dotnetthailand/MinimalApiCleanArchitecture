namespace Customer.Application.Features.CreateCustomer.Dto;

using FrameworkAgnostic.Common.Mappers;

public class CreateCustomerRequest : IMapFrom<Core.Entities.Customer>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Core.Entities.Customer, CreateCustomerRequest>()
            .ReverseMap();
    }
}
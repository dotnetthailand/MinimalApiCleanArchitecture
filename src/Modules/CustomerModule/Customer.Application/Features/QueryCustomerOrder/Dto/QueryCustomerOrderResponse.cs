namespace Customer.Application.Features.QueryCustomerOrder.Dto;

public class QueryCustomerOrderResponse : IMapFrom<Core.Entities.Customer>
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public List<OrderResponse> Orders { get; set; } = new List<OrderResponse>();
}

public class OrderResponse : IMapFrom<Core.Entities.Order>
{
    public long Id { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
}

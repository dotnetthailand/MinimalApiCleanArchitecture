namespace Customer.Core.Entities;

public class OrderLine : AuditableEntity
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public decimal Price { get; set; }
}

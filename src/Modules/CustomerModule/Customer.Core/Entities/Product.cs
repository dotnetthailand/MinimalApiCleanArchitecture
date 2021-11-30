namespace Customer.Core.Entities;

public  class Product : AuditableEntity
{
    public long Id { get; set; }
    public string?  Name { get; set; }
    public string? SKU { get; set; }
    public Decimal UnitPrice { get; set; }
}

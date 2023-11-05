namespace SmartPOS.Products.Domain.Taxes;

public record TaxId(Guid Value)
{
    public static TaxId New() => new(Guid.NewGuid());
}

namespace SmartPOS.Products.Domain.Products;

public record Sku(string Value)
{
    public static Sku New() => new(
       Convert.ToBase64String(
       Guid.NewGuid()
            .ToByteArray())
            .ToUpper()
        );
}
namespace SmartPOS.Products.Domain.Products;

public record Sku
{
    private Sku(string value)
    {
        Value = value;
    }

    public string? Value { get; init; }

    public static Sku New() => new(
        Guid.NewGuid()
            .ToString("N")
            .ToUpper()
        );

    public static Sku? Create(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        return new Sku(value);
    }
}
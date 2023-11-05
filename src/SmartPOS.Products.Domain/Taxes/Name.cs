namespace SmartPOS.Products.Domain.Taxes;

public record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        Value = value;
    }

    public static explicit operator string(Name name) => name.Value;
}
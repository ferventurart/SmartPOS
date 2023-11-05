namespace SmartPOS.Products.Domain.Shared;

public record Percentage
{
    public decimal Value { get; init; }

    public Percentage(decimal value)
    {
        decimal result = value / 100;
        Value = Math.Round(result, 2);
    }
}
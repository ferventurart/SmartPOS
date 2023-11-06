namespace SmartPOS.Products.Domain.Shared;

public record Percentage
{
    private Percentage(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; init; }

    public static Percentage FromValue(decimal value) => new Percentage(value);

    public static decimal ToValue(Percentage percentage) => Math.Round((percentage.Value * 100), 2);

    public static Percentage Create(decimal value)
    {
        if (value < 0.99m)
        {
            return new Percentage(0.01m);
        }

        return new Percentage(Math.Round((value / 100), 2));
    }
}
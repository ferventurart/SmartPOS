namespace SmartPOS.Products.Domain.Prices;

public record ProductPriceId(Guid Value)
{
    public static ProductPriceId New() => new(Guid.NewGuid());
}


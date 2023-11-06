using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Prices;

public sealed class ProductPrice : Entity<ProductPriceId>
{
    private ProductPrice(
        ProductPriceId id,
        ProductId productId,
        int number,
        Money price,
        Money priceWithTax,
        Percentage utility,
        int? priceStartingFrom)
        : base(id)
    {
        ProductId = productId;
        Number = number;
        Price = price;
        PriceWithTax = priceWithTax;
        Utility = utility;
        PriceStartingFrom = priceStartingFrom;
    }

    private ProductPrice()
    {

    }

    public ProductId ProductId { get; private set; }
    public int Number { get; private set; }
    public Money Price { get; private set; }
    public Money PriceWithTax { get; private set; }
    public Percentage Utility { get; private set; }
    public int? PriceStartingFrom { get; private set; }
    public static ProductPrice Create(
        ProductId productId,
        int number,
        Money cost,
        IReadOnlyList<Tax> taxes,
        Percentage utility,
        int priceStartingFrom)
    {
        var amount = Math.Round(cost.Amount + (cost.Amount * utility.Value), 2);
        var amountTaxes = decimal.Zero;

        foreach (Tax tax in taxes)
        {
            amountTaxes += amount * tax.Percentage.Value;
        }

        var price = new Money(amount, cost.Currency);
        var priceWithTaxes = new Money(Math.Round(amount + amountTaxes, 2), cost.Currency);

        return new ProductPrice(
            ProductPriceId.New(),
            productId,
            number,
            price,
            priceWithTaxes,
            utility,
            priceStartingFrom);
    }
}
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products;

public record Price
{
    private Price()
    {
    }

    public Money Amount { get; init; }
    public Money AmountWithTax { get; init; }
    public Percentage Utility { get; init; }


    public static Price Create(Money cost, Percentage utility, IReadOnlyList<Tax> taxes, Currency currency)
    {
        var amount = cost.Amount + (cost.Amount * utility.Value);
        var amountTaxes = 0.00m;

        foreach (Tax tax in taxes)
        {
            amountTaxes += amount * tax.Percentage.Value;
        }

        var amountWithTaxes = amount + amountTaxes;

        return new Price()
        {
            Amount = new Money(amount, currency),
            AmountWithTax = new Money(amountWithTaxes, currency),
            Utility = utility
        };
    }
}

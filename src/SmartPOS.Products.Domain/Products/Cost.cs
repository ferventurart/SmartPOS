using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products;

public record Cost
{
    private Cost()
    {
    }

    public Money Amount { get; init; }
    public Money AmountWithTax { get; init; }

    public static Cost Create(Money amount, IReadOnlyList<Tax> taxes, Currency currency)
    {
        var amountTaxes = 0.00m;

        foreach (Tax tax in taxes)
        {
            amountTaxes += amount.Amount * tax.Percentage.Value;
        }

        var amountWithTaxes = amount.Amount + amountTaxes;


        return new Cost()
        {
            Amount = amount,
            AmountWithTax = new Money(amountWithTaxes, currency)
        };
    }
}
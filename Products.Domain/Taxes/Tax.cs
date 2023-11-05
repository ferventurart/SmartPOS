using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;

namespace SmartPOS.Products.Domain.Taxes;

public sealed class Tax : Entity<TaxId>
{
    private Tax(
        TaxId id,
        Name name,
        Percentage percentage,
        bool addAutomatically)
        : base(id)
    {
        Name = name;
        Percentage = percentage;
        AddAutomatically = addAutomatically;
    }

    private Tax()
    {
    }

    public Name Name { get; private set; }
    public Percentage Percentage { get; private set; }
    public bool AddAutomatically { get; private set; }
    public List<Product> Products { get; private set; } = new();

    public static Tax Create(Name name, Percentage percentage, bool addAutomatically)
    {
        var tax = new Tax(TaxId.New(), name, percentage, addAutomatically);

        return tax;
    }

    public void Update(Name name, Percentage percentage, bool addAutomatically)
    {
        Name = name;
        Percentage = percentage;
        AddAutomatically = addAutomatically;
    }
}

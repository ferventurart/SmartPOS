using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Products.Events;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products;

public sealed class Product : Entity<ProductId>
{
    public Product(
    ProductId id,
    Barcode barcode,
    Sku sku,
    Name name,
    string? description,
    CategoryId categoryId,
    UnitOfMeasure unitOfMeasure,
    bool favorite,
    bool inventoryControl,
    Money cost,
    Money costWithTaxes,
    bool bulkSale,
    bool showInPos,
    ProductStatus status) : base(id)
    {
        Barcode = barcode;
        Sku = sku;
        Name = name;
        Description = description;
        CategoryId = categoryId;
        UnitOfMeasure = unitOfMeasure;
        Favorite = favorite;
        InventoryControl = inventoryControl;
        Cost = cost;
        CostWithTaxes = costWithTaxes;
        BulkSale = bulkSale;
        ShowInPos = showInPos;
        Status = status;
    }
    private Product()
    {
    }

    public Barcode Barcode { get; private set; }
    public Sku Sku { get; private set; }
    public Name Name { get; private set; }
    public string? Description { get; private set; }
    public CategoryId CategoryId { get; private set; }
    public UnitOfMeasure UnitOfMeasure { get; private set; }
    public bool Favorite { get; private set; }
    public bool InventoryControl { get; private set; }
    public Money Cost { get; private set; }
    public Money CostWithTaxes { get; private set; }
    public bool BulkSale { get; private set; }
    public bool ShowInPos { get; private set; }
    public ProductStatus Status { get; private set; }
    public List<Tax> Taxes { get; private set; } = new();

    public static Product Create(
    Barcode barcode,
    Sku sku,
    Name name,
    string? description,
    CategoryId categoryId,
    UnitOfMeasure unitOfMeasure,
    bool favorite,
    bool inventoryControl,
    Money cost,
    IReadOnlyList<Tax> taxes,
    bool bulkSale,
    bool showInPos,
    IReadOnlyList<decimal> utilityPercentages)
    {
        var amountTaxes = 0.00m;

        foreach (Tax tax in taxes)
        {
            amountTaxes += Math.Round(cost.Amount * tax.Percentage.Value, 2);
        }

        var costWithTaxes = new Money(Math.Round(cost.Amount + amountTaxes, 2), cost.Currency);

        var product = new Product(
            ProductId.New(),
            barcode,
            sku,
            name,
            description,
            categoryId,
            unitOfMeasure,
            favorite,
            inventoryControl,
            cost,
            costWithTaxes,
            bulkSale,
            showInPos,
            ProductStatus.Available);

        var taxIds = taxes.Select(s => s.Id)
                 .ToList()
                 .AsReadOnly();
        product.RaiseDomainEvent(new TaxAddedProductEvent(
            product.Id,
            taxIds
        ));

        product.RaiseDomainEvent(new RegisterProductPricesEvent(
           product.Id,
           utilityPercentages,
           taxIds,
           cost
        ));

        return product;
    }

    public void Deprecated() => Status = ProductStatus.Deprecated;
}

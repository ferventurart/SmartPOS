using Ardalis.SmartEnum;

namespace SmartPOS.Products.Domain.Products;

public sealed class ProductStatus : SmartEnum<ProductStatus>
{
    public static readonly ProductStatus Unavailable = new ProductStatus(nameof(Unavailable), 0);
    public static readonly ProductStatus Available = new ProductStatus(nameof(Available), 1);
    public static readonly ProductStatus Deprecated = new ProductStatus(nameof(Deprecated), 2);

    private ProductStatus(string name, int value) : base(name, value)
    {
    }
}
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products;

public sealed class ProductTax
{
    public ProductId ProductId { get; private set; }
    public TaxId TaxId { get; private set; }

    public ProductTax(ProductId productId, TaxId taxId)
    {
        ProductId = productId;
        TaxId = taxId;
    }
}

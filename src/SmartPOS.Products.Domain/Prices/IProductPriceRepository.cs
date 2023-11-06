using SmartPOS.Products.Domain.Products;

namespace SmartPOS.Products.Domain.Prices;

public interface IProductPriceRepository
{
    void Add(List<ProductPrice> productPrices);

    Task<IReadOnlyList<ProductPrice>> GetProductPrices(ProductId productId, CancellationToken cancellationToken = default);
}

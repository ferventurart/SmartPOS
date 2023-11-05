namespace SmartPOS.Products.Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellation = default);

    void Add(Product product);
}

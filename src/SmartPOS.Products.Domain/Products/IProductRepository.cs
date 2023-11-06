namespace SmartPOS.Products.Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellation = default);

    void AddTaxes(List<ProductTax> taxes);
    void Add(Product product);
}

using SmartPOS.Products.Domain.Products;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class ProductRepository : Repository<Product, ProductId>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext)
    : base(dbContext)
    {
    }

    public void AddTaxes(List<ProductTax> taxes)
    {
       DbContext.Set<ProductTax>()
                .AddRange(taxes);
    }
}

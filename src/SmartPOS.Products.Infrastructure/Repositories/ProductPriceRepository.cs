using Microsoft.EntityFrameworkCore;
using SmartPOS.Products.Domain.Prices;
using SmartPOS.Products.Domain.Products;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class ProductPriceRepository : Repository<ProductPrice, ProductPriceId>, IProductPriceRepository
{
    public ProductPriceRepository(ApplicationDbContext dbContext)
    : base(dbContext)
    {
    }

    public void Add(List<ProductPrice> productPrices)
    {
        DbContext.Set<ProductPrice>()
                 .AddRange(productPrices);
    }

    public async Task<IReadOnlyList<ProductPrice>> GetProductPrices(
        ProductId productId, 
        CancellationToken cancellationToken = default)
                => await DbContext.Set<ProductPrice>()
                            .AsNoTracking()
                            .Where(p => p.ProductId == productId)
                            .ToListAsync(cancellationToken);
}

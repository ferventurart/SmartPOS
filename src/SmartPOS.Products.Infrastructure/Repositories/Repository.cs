using Microsoft.EntityFrameworkCore;
using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbContext.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbContext.Remove(entity);
    }
}

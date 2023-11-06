using Microsoft.EntityFrameworkCore;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Taxes;
using System.Linq.Expressions;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class TaxRepository : Repository<Tax, TaxId>, ITaxRepository
{
    public TaxRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<bool> Exists(Name name, CancellationToken cancellationToken = default)
        => await DbContext.Set<Tax>()
                          .AsNoTracking()
                          .AnyAsync(a => a.Name == name, cancellationToken);

    public async Task<PagedList<Tax>> GetTaxes(
        string? searchTerm, 
        string? sortBy, 
        string? sortOrder, 
        int page, 
        int pageSize, 
        CancellationToken cancellation = default)
    {
        IQueryable<Tax> taxesQuery = DbContext.Set<Tax>().AsNoTracking();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            taxesQuery = taxesQuery
                                .Where(w => ((string)w.Name)
                                            .ToLower()
                                            .Contains(searchTerm.ToLower()));
        }

        Expression<Func<Tax, object>> keySelector = sortBy?.ToLower() switch
        {
            "name" => tax => tax.Name,
            _ => tax => tax.Id
        };

        if (sortOrder?.ToLower() == "desc")
        {
            taxesQuery = taxesQuery.OrderByDescending(keySelector);
        }
        else
        {
            taxesQuery = taxesQuery.OrderBy(keySelector);
        }

        return await PagedList<Tax>.CreateAsync(
                taxesQuery,
                page,
                pageSize,
                cancellation);
    }

    public async Task<IReadOnlyList<Tax>> GetSelectedTaxes(List<TaxId> taxIds, CancellationToken cancellationToken = default)
        => await DbContext.Set<Tax>()
                          .AsNoTracking()     
                          .Where(w => taxIds.Contains(w.Id))
                          .ToListAsync(cancellationToken); 
}

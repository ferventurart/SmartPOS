using Microsoft.EntityFrameworkCore;

namespace SmartPOS.Products.Domain.Abstractions;

public class PagedList<T>
{
    private PagedList(List<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public List<T> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => PageSize > 1;

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (page <= 0)
        {
            page = 1;
        }

        if (pageSize <= 0)
        {
            pageSize = 10;
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query.Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync(cancellationToken);

        return new(items, page, pageSize, totalCount);
    }

    public static PagedList<T> Create(List<T> items, int page, int pageSize, int totalCount)
    {
        return new(items, page, pageSize, totalCount);
    }
}

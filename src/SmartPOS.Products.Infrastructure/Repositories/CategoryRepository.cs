using Microsoft.EntityFrameworkCore;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;
using System.Linq.Expressions;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category, CategoryId>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<bool> ExistsCategoryWithSameNameInDepartment(
        DepartmentId departmentId,
        Domain.Categories.Name name,
        CancellationToken cancellationToken = default) =>
         await DbContext.Set<Category>()
                        .AsNoTracking()
                        .AnyAsync(a => a.DepartmentId == departmentId && a.Name == name);

    public async Task<PagedList<Category>> GetCategories(DepartmentId departmentId, string? searchTerm, string? sortBy, string? sortOrder, int page, int pageSize, CancellationToken cancellation = default)
    {
        IQueryable<Category> categoriesQuery = DbContext.Set<Category>()
                                                        .Where(w => w.DepartmentId == departmentId)
                                                        .AsNoTracking();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            categoriesQuery = categoriesQuery
                                .Where(w => ((string)w.Name)
                                            .ToLower()
                                            .Contains(searchTerm.ToLower()));
        }

        Expression<Func<Category, object>> keySelector = sortBy?.ToLower() switch
        {
            "name" => category => category.Name,
            _ => category => category.Id
        };

        if (sortOrder?.ToLower() == "desc")
        {
            categoriesQuery = categoriesQuery.OrderByDescending(keySelector);
        }
        else
        {
            categoriesQuery = categoriesQuery.OrderBy(keySelector);
        }

        return await PagedList<Category>.CreateAsync(
                categoriesQuery,
                page,
                pageSize,
                cancellation);
    }
}

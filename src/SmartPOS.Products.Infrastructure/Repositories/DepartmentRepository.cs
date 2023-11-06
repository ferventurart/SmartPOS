using Microsoft.EntityFrameworkCore;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;
using System.Linq.Expressions;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class DepartmentRepository : Repository<Department, DepartmentId>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<PagedList<Department>> GetDepartments(
        string? searchTerm,
        string? sortBy,
        string? sortOrder,
        int page,
        int pageSize,
        CancellationToken cancellation = default)
    {
        IQueryable<Department> departmentsQuery = DbContext.Set<Department>().AsNoTracking();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            departmentsQuery = departmentsQuery
                                .Where(w => ((string)w.Name)
                                            .ToLower()
                                            .Contains(searchTerm.ToLower()));
        }

        Expression<Func<Department, object>> keySelector = sortBy?.ToLower() switch
        {
            "name" => department => department.Name,
            _ => department => department.Id
        };

        if (sortOrder?.ToLower() == "desc")
        {
            departmentsQuery = departmentsQuery.OrderByDescending(keySelector);
        }
        else
        {
            departmentsQuery = departmentsQuery.OrderBy(keySelector);
        }

        return await PagedList<Department>.CreateAsync(
                departmentsQuery,
                page,
                pageSize,
                cancellation);
    }

    public async Task<bool> HasCategoriesAttached(DepartmentId id, CancellationToken cancellation = default) =>
            await DbContext.Set<Category>()
                           .AsNoTracking() 
                           .AnyAsync(a => a.DepartmentId == id, cancellation);
}

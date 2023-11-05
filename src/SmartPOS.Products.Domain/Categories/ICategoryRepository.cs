using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(CategoryId id, CancellationToken cancellationToken = default);
    Task<bool> ExistsCategoryWithSameNameInDepartment(DepartmentId departmentId, Name name, CancellationToken cancellationToken = default);
    Task<PagedList<Category>> GetCategories(
    DepartmentId departmentId,
    string? searchTerm,
    string? sortBy,
    string? sortOrder,
    int page,
    int pageSize,
    CancellationToken cancellation = default);

    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
}

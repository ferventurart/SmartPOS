using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Departments;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(DepartmentId id, CancellationToken cancellation = default);
    Task<PagedList<Department>> GetDepartments(
        string? searchTerm, 
        string? sortBy, 
        string? sortOrder, 
        int page, 
        int pageSize,
        CancellationToken cancellation = default);
    Task<bool> HasCategoriesAttached(DepartmentId id, CancellationToken cancellation = default);
    void Add(Department department);
    void Delete(Department department);
}

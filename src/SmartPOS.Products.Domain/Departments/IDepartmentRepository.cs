namespace SmartPOS.Products.Domain.Departments;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(DepartmentId id, CancellationToken cancellation = default);

    void Add(Department department);
}

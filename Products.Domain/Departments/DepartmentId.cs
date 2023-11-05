namespace SmartPOS.Products.Domain.Departments;

public record DepartmentId(Guid Value)
{
    public static DepartmentId New() => new(Guid.NewGuid());
}
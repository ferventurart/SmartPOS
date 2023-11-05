using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Departments;

public sealed class Department : Entity<DepartmentId>
{
    private Department(
        DepartmentId id,
        Name name)
        : base(id)
    {
        Name = name;
    }

    private Department()
    {
    }

    public Name Name { get; private set; }

    public static Department Create(Name name)
    {
        var department = new Department(DepartmentId.New(), name);

        return department;
    }

    public void Update(Name name) => Name = name;

}

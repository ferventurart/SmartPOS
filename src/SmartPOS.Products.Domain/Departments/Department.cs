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

    public static Department Create(string name)
    {
        var department = new Department(DepartmentId.New(), new Name(name));

        return department;
    }

    public void Update(string name) => Name = new Name(name);
}

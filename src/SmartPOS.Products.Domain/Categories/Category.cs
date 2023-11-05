using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Domain.Categories;

public sealed class Category : Entity<CategoryId>
{
    private Category(
        CategoryId id,
        DepartmentId departmentId,
        Name name)
        : base(id)
    {
        DepartmentId = departmentId;
        Name = name;
    }

    private Category()
    {
    }

    public DepartmentId DepartmentId { get; private set; }
    public Name Name { get; private set; }

    public static Category Create(
        DepartmentId departmentId,
        Name name)
    {
        var category = new Category(CategoryId.New(), departmentId, name);

        return category;
    }

    public void Update(DepartmentId departmentId, Name name)
    {
        DepartmentId = departmentId;
        Name = name;
    }
}

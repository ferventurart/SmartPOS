using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Departments;

public static class DepartmentErrors
{
    public static Error NotFound = new(
        "Department.Found",
        "The department with the specified identifier was not found.");

    public static Error CategoriesAttached = new(
       "Department.WithCategories",
       "The department has categories attached and it cannot be deleted.");
}
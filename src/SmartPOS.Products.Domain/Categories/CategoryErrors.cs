using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Categories;

public static class CategoryErrors
{
    public static Error NotFound = new(
        "Category.Found",
        "The category with the specified identifier was not found.");

    public static Error DepartmentAlredyHasCategory = new(
        "Category.NameDuplicated",
        "The category with the specified name is duplicated in the department selected.");
}
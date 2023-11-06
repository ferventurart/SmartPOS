using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Products;

public static class ProductErrors
{
    public static Error NotFound = new(
        "Product.Found",
        "The product with the specified identifier was not found.");

    public static Error NotValidUnitOfMeasure = new(
        "Product.UnitOfMeasure",
        "The unit of measure provided is not valid.");
}

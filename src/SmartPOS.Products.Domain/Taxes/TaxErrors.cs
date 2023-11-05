using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Taxes;

public static class TaxErrors
{
    public static Error NotFound = new(
        "Tax.Found",
        "The Tax with the specified identifier was not found.");

    public static Error AlreadyExits = new(
       "Tax.Duplicated",
       "The tax with the name provided already exists..");
}
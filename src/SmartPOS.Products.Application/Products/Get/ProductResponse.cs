namespace SmartPOS.Products.Application.Products.Get;

public record ProductResponse
(
    Guid ProductId,
    string? Barcode,
    string? Sku,
    string Name,
    string? Description,
    Guid CategoryId,
    string UnitOfMeasure,
    bool Favorite,
    bool InventoryControl,
    MoneyResponse Cost,
    MoneyResponse CostWithTaxes,
    bool BulkSale,
    bool ShowInPos,
    string Status
);

public record MoneyResponse(decimal Amount, string Currency);
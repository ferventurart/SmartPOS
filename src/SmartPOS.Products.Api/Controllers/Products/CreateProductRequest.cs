namespace SmartPOS.Products.Api.Controllers.Products;

public record CreateProductRequest(
    string? Barcode,
    string? Sku,
    bool GenerateSku,
    string Name,
    string? Description,
    Guid CategoryId,
    string UnitOfMeasure,
    bool Favorite,
    bool InventoryControl,
    decimal Cost,
    bool BulkSale,
    bool ShowInPos,
    IReadOnlyList<Guid> Taxes);

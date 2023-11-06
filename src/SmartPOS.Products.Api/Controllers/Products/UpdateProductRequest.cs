namespace SmartPOS.Products.Api.Controllers.Products;

public record UpdateProductRequest(
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
    List<Guid> Taxes,
    int Status);

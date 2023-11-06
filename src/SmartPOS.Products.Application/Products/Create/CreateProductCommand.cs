using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Products.Create;

public record CreateProductCommand(
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
    IReadOnlyList<Guid> Taxes,
    IReadOnlyList<decimal> UtilityPercentages) : ICommand<Guid>;

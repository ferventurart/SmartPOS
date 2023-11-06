using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products.Events;

public sealed record RegisterProductPricesEvent(
    ProductId ProductId,
    IReadOnlyList<decimal> UtilityPercentages,
    IReadOnlyList<TaxId> TaxIds,
    Money Cost) : IDomainEvent;

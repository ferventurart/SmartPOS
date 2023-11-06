using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Domain.Products.Events;

public sealed record TaxAddedProductEvent(ProductId ProductId, IReadOnlyList<TaxId> TaxIds) : IDomainEvent;
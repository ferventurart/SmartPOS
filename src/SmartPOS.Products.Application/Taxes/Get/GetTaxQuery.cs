using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Taxes.Get;

public record GetTaxQuery(Guid TaxId) : IQuery<TaxResponse>;

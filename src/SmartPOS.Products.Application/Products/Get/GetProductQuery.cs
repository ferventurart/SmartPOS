using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Products.Get;

public record GetProductQuery(Guid ProductId) : IQuery<ProductResponse>;

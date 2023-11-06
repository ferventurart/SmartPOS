using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Products.GetUnitOfMeasures;

public record GetUnitOfMeasuresQuery() : IQuery<IReadOnlyList<UnitOfMeasureResponse>>;
using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Products;

namespace SmartPOS.Products.Application.Products.GetUnitOfMeasures;

internal sealed class GetUnitOfMeasuresQueryHandler : IQueryHandler<GetUnitOfMeasuresQuery, IReadOnlyList<UnitOfMeasureResponse>>
{
    public async Task<Result<IReadOnlyList<UnitOfMeasureResponse>>> Handle(GetUnitOfMeasuresQuery request, CancellationToken cancellationToken)
    {
        var unitOfMeasures = UnitOfMeasure.List
                .Select(u => new UnitOfMeasureResponse(u.Name))
                .ToList();

        return await Task.FromResult(unitOfMeasures);
    }
}

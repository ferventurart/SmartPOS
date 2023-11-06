using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Taxes.Get;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Taxes.GetAll;

internal sealed class GetTaxesQueryHandler : IQueryHandler<GetTaxesQuery, PagedList<TaxResponse>>
{
    private readonly ITaxRepository _repository;

    public GetTaxesQueryHandler(ITaxRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PagedList<TaxResponse>>> Handle(GetTaxesQuery request, CancellationToken cancellationToken)
    {
        var taxes = await _repository
                  .GetTaxes(
                   request.SearchTerm,
                   request.SortBy,
                   request.SortOrder,
                   request.Page,
                   request.PageSize,
                   cancellationToken);

        return PagedList<TaxResponse>.Create(
               taxes.Items
                           .Select(s => new TaxResponse(
                               s.Id.Value, 
                               s.Name.Value, 
                               Percentage.ToValue(s.Percentage), 
                               s.AddAutomatically))
                           .ToList(),
                taxes.Page,
                taxes.PageSize,
                taxes.TotalCount);
    }
}

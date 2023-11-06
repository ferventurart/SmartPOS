using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Taxes.Get;

internal sealed class GetTaxQueryHandler : IQueryHandler<GetTaxQuery, TaxResponse>
{
    private readonly ITaxRepository _repository;

    public GetTaxQueryHandler(ITaxRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TaxResponse>> Handle(GetTaxQuery request, CancellationToken cancellationToken)
    {
        var tax = await _repository.GetByIdAsync(new TaxId(request.TaxId), cancellationToken);

        if (tax is null)
        {
            return Result.Failure<TaxResponse>(TaxErrors.NotFound);
        }

        return new TaxResponse(
            tax.Id.Value,
            tax.Name.Value,
            Percentage.ToValue(tax.Percentage),
            tax.AddAutomatically);
    }
}

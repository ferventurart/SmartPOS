using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Taxes.Update;

internal sealed class UpdateTaxCommandHandler : ICommandHandler<UpdateTaxCommand>
{
    private readonly ITaxRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTaxCommandHandler(ITaxRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
    {
        var tax = await _repository.GetByIdAsync(new TaxId(request.TaxId), cancellationToken);

        if (tax is null)
        {
            return Result.Failure(TaxErrors.NotFound);
        }

        tax.Update(
            new Name(request.Name),
            Percentage.Create(request.Percentage),
            request.AddAutomatically);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

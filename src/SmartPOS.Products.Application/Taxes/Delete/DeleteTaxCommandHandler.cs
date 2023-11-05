using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Taxes.Delete;

internal sealed class DeleteTaxCommandHandler : ICommandHandler<DeleteTaxCommand>
{
    private readonly ITaxRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaxCommandHandler(ITaxRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
    {
        var tax = await _repository.GetByIdAsync(new TaxId(request.TaxId), cancellationToken);

        if (tax is null)
        {
            return Result.Failure(TaxErrors.NotFound);
        }

        _repository.Delete(tax);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

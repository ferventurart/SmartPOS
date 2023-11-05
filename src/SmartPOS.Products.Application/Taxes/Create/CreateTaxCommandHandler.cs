using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Taxes.Create;

internal sealed class CreateTaxCommandHandler : ICommandHandler<CreateTaxCommand, Guid>
{
    private readonly ITaxRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTaxCommandHandler(ITaxRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
    {
        var taxName = new Name(request.Name);
        var tax = Tax.Create(
            taxName,
            new Percentage(request.Percentage),
            request.AddAutomatically);

        if(await _repository.Exists(taxName))
        {
            return Result.Failure<Guid>(TaxErrors.AlreadyExits);
        }

        _repository.Add(tax);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return tax.Id.Value;
    }
}

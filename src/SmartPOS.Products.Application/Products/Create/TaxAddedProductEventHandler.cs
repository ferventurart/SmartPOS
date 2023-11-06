using MediatR;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Products.Events;

namespace SmartPOS.Products.Application.Products.Create;

internal sealed class TaxAddedProductEventHandler : INotificationHandler<TaxAddedProductEvent>
{
    private readonly IProductRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TaxAddedProductEventHandler(IProductRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TaxAddedProductEvent notification, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(notification.ProductId, cancellationToken);

        if (product is null)
        {
            return;
        }

        List<ProductTax> productTaxes = new();

        foreach (var taxId in notification.TaxIds)
        {
            productTaxes.Add(new ProductTax(product.Id, taxId));
        }

        _repository.AddTaxes(productTaxes);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

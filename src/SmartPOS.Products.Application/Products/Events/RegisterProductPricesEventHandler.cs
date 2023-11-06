using MediatR;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Prices;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Products.Events;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Products.Events;

internal sealed class RegisterProductPricesEventHandler : INotificationHandler<RegisterProductPricesEvent>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductPriceRepository _priceRepository;
    private readonly ITaxRepository _taxRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductPricesEventHandler(IProductRepository productRepository, IProductPriceRepository priceRepository, ITaxRepository taxRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _priceRepository = priceRepository;
        _taxRepository = taxRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterProductPricesEvent notification, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(notification.ProductId, cancellationToken);

        if (product is null)
        {
            return;
        }

        var taxes = await _taxRepository.GetSelectedTaxes(
                    notification.TaxIds.ToList(),
                    cancellationToken);

        int number = 1;
        List<ProductPrice> productPrices = new();

        foreach (var utilityPercentage in notification.UtilityPercentages)
        {
            productPrices.Add(ProductPrice.Create(
                product.Id, 
                number, 
                notification.Cost,
                taxes,
                Percentage.Create(utilityPercentage), 
                1));

            number++;
        }

        _priceRepository.Add(productPrices);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

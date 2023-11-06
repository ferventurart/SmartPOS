using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Products;
using SmartPOS.Products.Domain.Shared;
using SmartPOS.Products.Domain.Taxes;

namespace SmartPOS.Products.Application.Products.Create;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITaxRepository _taxRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, ITaxRepository taxRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _taxRepository = taxRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var sku = request.GenerateSku ? Sku.New() : Sku.Create(request.Sku);

        var taxes = await _taxRepository.GetSelectedTaxes(
                            request.Taxes
                           .Select(s => new TaxId(s))
                           .ToList(),
                            cancellationToken);

        if(!UnitOfMeasure.TryFromName(request.UnitOfMeasure, out var unitOfmeasure))
        {
            return Result.Failure<Guid>(ProductErrors.NotValidUnitOfMeasure);
        }

        var product = Product.Create(
            new Barcode(request.Barcode),
            sku,
            new Domain.Products.Name(request.Name),
            request.Description,
            new CategoryId(request.CategoryId),
            unitOfmeasure,
            request.Favorite,
            request.InventoryControl,
            new Money(request.Cost, Currency.Usd),
            taxes,
            request.BulkSale,
            request.ShowInPos);

        _productRepository.Add(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return product.Id.Value;
    }
}

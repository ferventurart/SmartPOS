using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Products;

namespace SmartPOS.Products.Application.Products.Get;

internal sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductResponse>
{
    private readonly IProductRepository _repository;

    public GetProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(new ProductId(request.ProductId), cancellationToken);
        
        if (product is null)
        {
            return Result.Failure<ProductResponse>(ProductErrors.NotFound);
        }

        return new ProductResponse(
              product.Id.Value,
              product.Barcode?.Value,
              product.Sku?.Value,
              product.Name.Value,
              product.Description,
              product.CategoryId.Value,
              product.UnitOfMeasure.Name,
              product.Favorite,
              product.InventoryControl,
              new MoneyResponse(product.Cost.Amount, product.Cost.Currency.Code),
              new MoneyResponse(product.CostWithTaxes.Amount, product.CostWithTaxes.Currency.Code),
              product.BulkSale,
              product.ShowInPos,
              product.Status.Name);

    }
}

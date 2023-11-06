using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Products.Application.Categories.Get;
using SmartPOS.Products.Application.Products.Create;
using SmartPOS.Products.Application.Products.Get;
using SmartPOS.Products.Application.Products.GetUnitOfMeasures;

namespace SmartPOS.Products.Api.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("/unit-of-measures")]
    public async Task<IActionResult> GetUnitOfMeasures(CancellationToken cancellationToken)
    {
        var query = new GetUnitOfMeasuresQuery();

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
    CreateProductRequest request,
    CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand(
           request.Barcode,
           request.Sku,
           request.GenerateSku,
           request.Name,
           request.Description,
           request.CategoryId,
           request.UnitOfMeasure,
           request.Favorite,
           request.InventoryControl,
           request.Cost,
           request.BulkSale,
           request.ShowInPos,
           request.Taxes,
           request.UtilityPercentages);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetProduct), new { id = result.Value }, result.Value);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Products.Application.Taxes.Create;
using SmartPOS.Products.Application.Taxes.Delete;
using SmartPOS.Products.Application.Taxes.Get;
using SmartPOS.Products.Application.Taxes.GetAll;
using SmartPOS.Products.Application.Taxes.Update;

namespace SmartPOS.Products.Api.Controllers.Taxes;


[ApiController]
[Route("api/taxes")]
public class TaxesController : ControllerBase
{
    private readonly ISender _sender;

    public TaxesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetTaxes(
    string? searchTerm,
    string? sortBy,
    string? sortOrder,
    CancellationToken cancellationToken,
    int page = 1,
    int pageSize = 10)
    {
        var query = new GetTaxesQuery(
            searchTerm,
            sortBy,
            sortOrder,
            page,
            pageSize);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTax(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTaxQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTax(
    CreateTaxRequest request,
    CancellationToken cancellationToken)
    {
        var command = new CreateTaxCommand(request.Name, request.Percentage, request.AddAutomatically);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetTax), new { id = result.Value }, result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTax(
    Guid id,
    UpdateTaxRequest request,
    CancellationToken cancellationToken)
    {
        var command = new UpdateTaxCommand(id, request.Name, request.Percentage, request.AddAutomatically);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTax(
    Guid id,
    CancellationToken cancellationToken)
    {
        var command = new DeleteTaxCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }
}

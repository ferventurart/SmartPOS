using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Products.Application.Categories.Create;
using SmartPOS.Products.Application.Categories.Delete;
using SmartPOS.Products.Application.Categories.Get;
using SmartPOS.Products.Application.Categories.GetAll;
using SmartPOS.Products.Application.Categories.Update;

namespace SmartPOS.Products.Api.Controllers.Categories;


[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories(
    Guid departmentId,
    string? searchTerm,
    string? sortBy,
    string? sortOrder,
    CancellationToken cancellationToken,
    int page = 1,
    int pageSize = 10)
    {
        var query = new GetCategoriesQuery(
            departmentId,
            searchTerm,
            sortBy,
            sortOrder,
            page,
            pageSize);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(
    CreateCategoryRequest request,
    CancellationToken cancellationToken)
    {
        var command = new CreateCategoryCommand(request.DepartmentId, request.Name);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetCategory), new { id = result.Value }, result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(
    Guid id,
    UpdateCategoryRequest request,
    CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(id, request.DepartmentId, request.Name);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(
    Guid id,
    CancellationToken cancellationToken)
    {
        var command = new DeleteCategoryCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }
}

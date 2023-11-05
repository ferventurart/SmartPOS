using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartPOS.Products.Application.Departments.Create;
using SmartPOS.Products.Application.Departments.Delete;
using SmartPOS.Products.Application.Departments.Get;
using SmartPOS.Products.Application.Departments.GetAll;
using SmartPOS.Products.Application.Departments.Update;

namespace SmartPOS.Products.Api.Controllers.Departments;


[ApiController]
[Route("api/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly ISender _sender;

    public DepartmentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments(
    string? searchTerm,
    string? sortBy,
    string? sortOrder,
    CancellationToken cancellationToken,
    int page = 1,
    int pageSize = 10)
    {
        var query = new GetDepartmentsQuery(
            searchTerm,
            sortBy,
            sortOrder,
            page,
            pageSize);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(
    CreateDepartmentRequest request,
    CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentCommand(request.Name);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetDepartment), new { id = result.Value }, result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateDepartment(
    Guid id,
    UpdateDepartmentRequest request,
    CancellationToken cancellationToken)
    {
        var command = new UpdateDepartmentCommand(id, request.Name);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteDepartment(
    Guid id,
    CancellationToken cancellationToken)
    {
        var command = new DeleteDepartmentCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }
}

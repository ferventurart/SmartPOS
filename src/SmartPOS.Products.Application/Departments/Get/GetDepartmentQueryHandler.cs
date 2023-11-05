using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Departments.Get;

internal sealed class GetDepartmentQueryHandler : IQueryHandler<GetDepartmentQuery, DepartmentResponse>
{
    private readonly IDepartmentRepository _repository;

    public GetDepartmentQueryHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<DepartmentResponse>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync(new DepartmentId(request.DepartmentId), cancellationToken);

        if (department is null)
        {
            return Result.Failure<DepartmentResponse>(DepartmentErrors.NotFound);
        }

        return new DepartmentResponse(department.Id.Value, department.Name.Value);
    }
}

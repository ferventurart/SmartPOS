using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Departments.Get;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Departments.GetAll;

internal sealed class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, PagedList<DepartmentResponse>>
{
    private readonly IDepartmentRepository _repository;

    public GetDepartmentsQueryHandler(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PagedList<DepartmentResponse>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _repository
                          .GetDepartments(
                           request.SearchTerm,
                           request.SortBy,
                           request.SortOrder,
                           request.Page,
                           request.PageSize,
                           cancellationToken);

        return PagedList<DepartmentResponse>.Create(
               departments.Items
                           .Select(s => new DepartmentResponse(s.Id.Value, s.Name.Value))
                           .ToList(),
                departments.Page,
                departments.PageSize,
                departments.TotalCount);
    }
}

using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Categories.Get;
using SmartPOS.Products.Application.Departments.Get;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Categories.GetAll;

internal sealed class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, PagedList<CategoryResponse>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<PagedList<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository
                   .GetCategories(
                    new DepartmentId(request.DepartmentId),
                    request.SearchTerm,
                    request.SortBy,
                    request.SortOrder,
                    request.Page,
                    request.PageSize,
                    cancellationToken);

        return PagedList<CategoryResponse>.Create(
               categories.Items
                           .Select(s => new CategoryResponse(s.Id.Value, s.DepartmentId.Value, s.Name.Value))
                           .ToList(),
                categories.Page,
                categories.PageSize,
                categories.TotalCount);
    }
}

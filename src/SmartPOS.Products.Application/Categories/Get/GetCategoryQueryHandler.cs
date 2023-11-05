using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;

namespace SmartPOS.Products.Application.Categories.Get;

internal sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryResponse>
{
    private readonly ICategoryRepository _repository;
    public GetCategoryQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(new CategoryId(request.CategoryId), cancellationToken);

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(CategoryErrors.NotFound);
        }

        return new CategoryResponse(category.Id.Value, category.DepartmentId.Value, category.Name.Value);
    }
}

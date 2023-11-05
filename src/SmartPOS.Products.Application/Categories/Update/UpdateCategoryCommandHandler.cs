using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Categories.Update;

internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(new DepartmentId(request.DepartmentId), cancellationToken);

        if (department is null)
        {
            return Result.Failure(DepartmentErrors.NotFound);
        }

        var category = await _categoryRepository.GetByIdAsync(new CategoryId(request.CategoryId), cancellationToken);

        if (category is null)
        {
            return Result.Failure(CategoryErrors.NotFound);
        }

        var categoryName = new Domain.Categories.Name(request.Name);

        if (await _categoryRepository.ExistsCategoryWithSameNameInDepartment(department.Id, categoryName, cancellationToken))
        {
            return Result.Failure(CategoryErrors.DepartmentAlredyHasCategory);
        }

        category.Update(department.Id, categoryName);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

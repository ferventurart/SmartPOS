using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Categories;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Categories.Create;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetByIdAsync(new DepartmentId(request.DepartmentId), cancellationToken);

        if (department is null)
        {
            return Result.Failure<Guid>(DepartmentErrors.NotFound);
        }

        var categoryName = new Domain.Categories.Name(request.Name);

        if (await _categoryRepository.ExistsCategoryWithSameNameInDepartment(department.Id, categoryName, cancellationToken))
        {
            return Result.Failure<Guid>(CategoryErrors.DepartmentAlredyHasCategory);
        }

        var category = Category.Create(department.Id, categoryName);

        _categoryRepository.Add(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id.Value;
    }
}

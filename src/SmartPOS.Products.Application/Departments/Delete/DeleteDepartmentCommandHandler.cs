using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Departments.Delete;

internal sealed class DeleteDepartmentCommandHandler : ICommandHandler<DeleteDepartmentCommand>
{
    private readonly IDepartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDepartmentCommandHandler(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync(new DepartmentId(request.DepartmentId), cancellationToken);

        if (department is null)
        {
            return Result.Failure(DepartmentErrors.NotFound);
        }

        if (await _repository.HasCategoriesAttached(department.Id))
        {
            return Result.Failure(DepartmentErrors.CategoriesAttached);
        }

        _repository.Delete(department);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

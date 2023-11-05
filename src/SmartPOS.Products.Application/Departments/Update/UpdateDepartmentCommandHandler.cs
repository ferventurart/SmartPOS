using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Departments.Update;

internal sealed class UpdateDepartmentCommandHandler : ICommandHandler<UpdateDepartmentCommand>
{
    private readonly IDepartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDepartmentCommandHandler(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _repository.GetByIdAsync(new DepartmentId(request.DepartmentId), cancellationToken);

        if (department is null)
        {
            return Result.Failure(DepartmentErrors.NotFound);
        }

        department.Update(request.Name);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Abstractions;
using SmartPOS.Products.Domain.Departments;

namespace SmartPOS.Products.Application.Departments.Create;

internal sealed class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, Guid>
{
    private readonly IDepartmentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDepartmentCommandHandler(IDepartmentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = Department.Create(request.Name);

        _repository.Add(department);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return department.Id.Value;
    }
}

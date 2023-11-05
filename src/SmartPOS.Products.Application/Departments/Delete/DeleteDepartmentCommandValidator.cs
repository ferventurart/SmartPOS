using FluentValidation;

namespace SmartPOS.Products.Application.Departments.Delete;

public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
            RuleFor(r => r.DepartmentId)
               .NotEmpty();
    }
}

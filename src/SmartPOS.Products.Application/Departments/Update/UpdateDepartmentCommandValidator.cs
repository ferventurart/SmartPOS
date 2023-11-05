using FluentValidation;

namespace SmartPOS.Products.Application.Departments.Update;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(r => r.DepartmentId)
           .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(60);
    }
}

using FluentValidation;

namespace SmartPOS.Products.Application.Departments.Create;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(60);
    }
}

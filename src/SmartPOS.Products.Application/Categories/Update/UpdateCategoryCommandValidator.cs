using FluentValidation;

namespace SmartPOS.Products.Application.Categories.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(r => r.CategoryId)
            .NotEmpty();

        RuleFor(r => r.DepartmentId)
            .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(60);
    }
}
using FluentValidation;

namespace SmartPOS.Products.Application.Taxes.Create;

public class CreateTaxCommandValidator : AbstractValidator<CreateTaxCommand>
{
    public CreateTaxCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(r => r.Percentage)
            .GreaterThan(0)
            .NotEmpty();
    }
}

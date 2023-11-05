using FluentValidation;

namespace SmartPOS.Products.Application.Taxes.Update;

public class UpdateTaxCommandValidator : AbstractValidator<UpdateTaxCommand>
{
    public UpdateTaxCommandValidator()
    {
        RuleFor(r => r.TaxId)
            .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(r => r.Percentage)
            .GreaterThan(0)
            .NotEmpty();
    }
}

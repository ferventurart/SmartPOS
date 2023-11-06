using FluentValidation;

namespace SmartPOS.Products.Application.Products.Create;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Barcode)
            .MaximumLength(60);

        RuleFor(r => r.Sku)
            .MaximumLength(60);

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(75);

        RuleFor(r => r.Description)
            .MaximumLength(300);

        RuleFor(r => r.Cost)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(r => r.UnitOfMeasure)
           .NotEmpty()
           .MaximumLength(3);
    }
}

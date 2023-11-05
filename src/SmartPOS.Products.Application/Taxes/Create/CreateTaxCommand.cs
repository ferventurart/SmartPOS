using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Domain.Shared;

namespace SmartPOS.Products.Application.Taxes.Create;

public record CreateTaxCommand(
        string Name,
        decimal Percentage,
        bool AddAutomatically) : ICommand<Guid>;


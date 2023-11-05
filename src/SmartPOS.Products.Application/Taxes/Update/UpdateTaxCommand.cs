using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Taxes.Update;

public record UpdateTaxCommand(
        Guid TaxId,
        string Name,
        decimal Percentage,
        bool AddAutomatically) : ICommand;


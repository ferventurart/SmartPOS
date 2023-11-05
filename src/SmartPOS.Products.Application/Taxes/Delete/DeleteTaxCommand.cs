using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Taxes.Delete;

public record DeleteTaxCommand(Guid TaxId) : ICommand;
namespace SmartPOS.Products.Application.Taxes.Get;

public record TaxResponse(
    Guid TaxId, 
    string Name, 
    decimal Percentage,
    bool AddAutomatically);

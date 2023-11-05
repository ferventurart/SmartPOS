namespace SmartPOS.Products.Api.Controllers.Taxes;

public record UpdateTaxRequest(string Name, decimal Percentage, bool AddAutomatically);

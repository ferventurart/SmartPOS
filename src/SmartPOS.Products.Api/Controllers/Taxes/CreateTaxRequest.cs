namespace SmartPOS.Products.Api.Controllers.Taxes;

public record CreateTaxRequest(string Name, decimal Percentage, bool AddAutomatically);

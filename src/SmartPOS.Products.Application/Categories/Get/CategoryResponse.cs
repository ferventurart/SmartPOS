namespace SmartPOS.Products.Application.Categories.Get;

public record CategoryResponse(
    Guid CategoryId, 
    Guid DepartmentId, 
    string Name);
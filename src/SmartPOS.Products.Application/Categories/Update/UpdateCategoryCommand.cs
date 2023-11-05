using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Categories.Update;

public record UpdateCategoryCommand(Guid CategoryId, Guid DepartmentId, string Name) : ICommand;
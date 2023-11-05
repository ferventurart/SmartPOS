using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Categories.Create;

public record CreateCategoryCommand(Guid DepartmentId, string Name) : ICommand<Guid>;
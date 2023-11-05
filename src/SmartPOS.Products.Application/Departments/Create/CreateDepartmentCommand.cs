using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Departments.Create;

public record CreateDepartmentCommand(string Name) : ICommand<Guid>;
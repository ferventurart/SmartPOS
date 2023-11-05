using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Departments.Update;

public record UpdateDepartmentCommand(Guid DepartmentId, string Name) : ICommand;

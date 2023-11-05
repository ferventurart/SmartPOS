using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Departments.Delete;

public record DeleteDepartmentCommand(Guid DepartmentId) : ICommand;

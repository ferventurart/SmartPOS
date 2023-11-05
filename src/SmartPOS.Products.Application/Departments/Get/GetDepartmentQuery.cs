using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Departments.Get;

public record GetDepartmentQuery(Guid DepartmentId) : IQuery<DepartmentResponse>;

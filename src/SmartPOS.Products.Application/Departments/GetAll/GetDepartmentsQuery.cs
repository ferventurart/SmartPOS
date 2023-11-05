using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Departments.Get;
using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Application.Departments.GetAll;

public record GetDepartmentsQuery(
        string? SearchTerm,
        string? SortBy,
        string? SortOrder,
        int Page,
        int PageSize) : IQuery<PagedList<DepartmentResponse>>;

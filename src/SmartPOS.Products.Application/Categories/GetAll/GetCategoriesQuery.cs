using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Categories.Get;
using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Application.Categories.GetAll;

public record GetCategoriesQuery(
        Guid DepartmentId,
        string? SearchTerm,
        string? SortBy,
        string? SortOrder,
        int Page,
        int PageSize) : IQuery<PagedList<CategoryResponse>>;
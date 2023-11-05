using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Categories.Get;

public record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;

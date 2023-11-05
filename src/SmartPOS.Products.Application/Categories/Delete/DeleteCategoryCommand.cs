using SmartPOS.Products.Application.Abstractions.Messaging;

namespace SmartPOS.Products.Application.Categories.Delete;

public record DeleteCategoryCommand(Guid CategoryId) : ICommand;

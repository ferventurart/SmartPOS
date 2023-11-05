using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
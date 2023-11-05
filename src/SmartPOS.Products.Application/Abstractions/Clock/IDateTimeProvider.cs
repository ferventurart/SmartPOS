namespace SmartPOS.Products.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
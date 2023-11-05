using SmartPOS.Products.Application.Abstractions.Clock;

namespace SmartPOS.Products.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
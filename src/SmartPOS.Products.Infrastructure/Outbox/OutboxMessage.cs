namespace SmartPOS.Products.Infrastructure.Outbox;

public sealed class OutboxMessage
{
    public OutboxMessage(Guid id, DateTime occurredOnUtc, string type, string content)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
        Content = content;
        Type = type;
    }

    public Guid Id { get; private set; }

    public DateTime OccurredOnUtc { get; private set; }

    public string Type { get; private set; }

    public string Content { get; private set; }

    public DateTime? ProcessedOnUtc { get; private set; }

    public string? Error { get; private set; }
}

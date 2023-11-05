﻿namespace SmartPOS.Products.Domain.Products;

public record ProductId(Guid Value)
{
    public static ProductId New() => new(Guid.NewGuid());
}

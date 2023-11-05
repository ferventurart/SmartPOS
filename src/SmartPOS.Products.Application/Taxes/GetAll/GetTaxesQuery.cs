using SmartPOS.Products.Application.Abstractions.Messaging;
using SmartPOS.Products.Application.Taxes.Get;
using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Application.Taxes.GetAll;

public record GetTaxesQuery(
        string? SearchTerm,
        string? SortBy,
        string? SortOrder,
        int Page,
        int PageSize) : IQuery<PagedList<TaxResponse>>;


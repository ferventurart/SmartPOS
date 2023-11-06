using SmartPOS.Products.Domain.Abstractions;

namespace SmartPOS.Products.Domain.Taxes;

public interface ITaxRepository
{
    Task<Tax?> GetByIdAsync(TaxId id, CancellationToken cancellationToken = default);
    Task<bool> Exists(Name name, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Tax>> GetSelectedTaxes(List<TaxId> taxIds, CancellationToken cancellationToken = default);
    Task<PagedList<Tax>> GetTaxes(
        string? searchTerm,
        string? sortBy,
        string? sortOrder,
        int page,
        int pageSize,
        CancellationToken cancellation = default);
    void Add(Tax tax);
    void Update(Tax tax);
    void Delete(Tax tax);
}

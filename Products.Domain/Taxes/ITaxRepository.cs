namespace SmartPOS.Products.Domain.Taxes;

public interface ITaxRepository
{
    Task<Tax?> GetByIdAsync(TaxId id, CancellationToken cancellationToken = default);
    void Add(Tax tax, CancellationToken cancellationToken = default);
    void Update(Tax tax, CancellationToken cancellationToken = default);
    void Delete(Tax tax, CancellationToken cancellationToken = default);
}

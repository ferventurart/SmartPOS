namespace SmartPOS.Products.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(CategoryId id, CancellationToken cancellationToken = default);
    void Add(Category category, CancellationToken cancellationToken = default);
    void Update(Category category, CancellationToken cancellationToken = default);
    void Delete(Category category, CancellationToken cancellationToken = default);
}

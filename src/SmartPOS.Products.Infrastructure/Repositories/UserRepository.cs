using SmartPOS.Products.Domain.Users;

namespace SmartPOS.Products.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
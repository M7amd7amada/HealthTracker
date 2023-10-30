namespace HealthTracker.Data.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext, ILogger logger)
        : base(dbContext, logger) { }

    public override async Task<IEnumerable<User>> GetAll()
    {
        try
        {
            var users = dbSet.Where(u => u.Status == Status.Active);
            return await users.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(GetAll), typeof(UserRepository));
            return Enumerable.Empty<User>();
        }
    }

    public async Task<User> GetUserPerEmail(string email)
    {
        try
        {
            return await dbSet.Where(u => u.Email == email).FirstOrDefaultAsync()
                ?? throw new ArgumentNullException(nameof(email));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(GetUserPerEmail), typeof(UserRepository));
            return new User();
        }
    }
}
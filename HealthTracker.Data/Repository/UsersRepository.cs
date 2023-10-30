namespace HealthTracker.Data.Repository;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(AppDbContext dbContext, ILogger logger)
        : base(dbContext, logger) { }

    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            var users = dbSet.Where(u => u.Status == Status.Active);
            return await users.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(GetAllAsync), typeof(UsersRepository));
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
            logger.LogError(ex, nameof(GetUserPerEmail), typeof(UsersRepository));
            return new User();
        }
    }
}
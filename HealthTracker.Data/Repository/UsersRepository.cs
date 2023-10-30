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

    public override async Task<bool> AddAsync(User entity)
    {
        try
        {
            return await base.AddAsync(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(AddAsync), typeof(UsersRepository));
            return false;
        }
    }

    public override async Task<User> GetByIdAsync(Guid id)
    {
        try
        {
            return await base.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(GetByIdAsync), typeof(UsersRepository));
            return new User();
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
namespace HealthTracker.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext context;
    protected readonly ILogger logger;
    internal readonly DbSet<T> dbSet;

    public GenericRepository(AppDbContext dbContext, ILogger logger)
    {
        context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        dbSet = dbContext.Set<T>();
        this.logger = logger;
    }

    public virtual async Task<bool> Add(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await dbSet.AddAsync(entity);
        context.SaveChanges();
        return true;
    }

    public virtual Task<bool> Delete(Guid id, string userId)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<T> GetById(Guid id)
    {
        return await dbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
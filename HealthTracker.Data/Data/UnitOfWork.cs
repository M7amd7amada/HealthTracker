using HealthTracker.Data.Configuration;
using HealthTracker.Data.Repository;

namespace HealthTracker.Data.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("db_logs");

        Users = new UsersRepository(_context, _logger);
    }
    public IUsersRepository Users { get; private set; }

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
namespace HealthTracker.Data.Configuration;

public interface IUnitOfWork
{
    public IUsersRepository Users { get; }
    public Task CompleteAsync();
}
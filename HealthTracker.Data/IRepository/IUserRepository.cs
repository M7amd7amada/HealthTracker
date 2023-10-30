namespace HealthTracker.Data.IRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserPerEmail(string email);
}
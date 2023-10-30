namespace HealthTracker.Data.IRepository;

public interface IUsersRepository : IGenericRepository<User>
{
    public Task<User> GetUserPerEmail(string email);
}
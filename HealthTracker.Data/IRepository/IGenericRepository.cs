namespace HealthTracker.Data.IRepository;

public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task<bool> Add(T entity);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(Guid id, string userId);
}
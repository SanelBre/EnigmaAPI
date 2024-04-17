namespace DataAccess;

public interface IDataStorage<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate);
    public Task<T> GetAsync(Func<T, bool> predicate);
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(int id);
}

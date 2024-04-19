namespace EnigmaAPI.DataAccess;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(string id);
    public Task<IEnumerable<T>> GetAllWhereAsync(Func<T, bool> predicate);
    public Task<T> GetWhereAsync(Func<T, bool> predicate);
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(string id);
}

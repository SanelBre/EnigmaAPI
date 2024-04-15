namespace DataAccess;

public class Repository<T> : IRepository<T>
{
    private readonly IDataStorage<T> _dataStorage;

    public Repository(IDataStorage<T> dataStorage)
    {
        _dataStorage = dataStorage ?? throw new ArgumentNullException(nameof(dataStorage));
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return _dataStorage.GetAllAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _dataStorage.GetByIdAsync(id);
    }

    public Task AddAsync(T entity)
    {
        return _dataStorage.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        return _dataStorage.UpdateAsync(entity);
    }

    public Task DeleteAsync(int id)
    {
        return _dataStorage.DeleteAsync(id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess;

public class MemoryStorage<T> : IDataStorage<T>
{
    private readonly List<T> _data;
    private readonly object _lock = new object();

    public MemoryStorage()
    {
        _data = new List<T>();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_data.AsEnumerable());
        }
    }

    public Task<T> GetByIdAsync(int id)
    {
        lock (_lock)
        {
            return Task.FromResult(_data.FirstOrDefault());
        }
    }

    public Task AddAsync(T entity)
    {
        lock (_lock)
        {
            _data.Add(entity);
            return Task.CompletedTask;
        }
    }

    public Task UpdateAsync(T entity)
    {
        lock (_lock)
        {
            return Task.CompletedTask;
        }
    }

    public Task DeleteAsync(int id)
    {
        lock (_lock)
        {
            return Task.CompletedTask;
        }
    }
}


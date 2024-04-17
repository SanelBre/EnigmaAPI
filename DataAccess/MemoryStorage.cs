using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace DataAccess;

public class MemoryStorage<T> : IDataStorage<T> where T : IEntity
{
    private readonly List<T> _data;
    private readonly object _lock = new object();

    public MemoryStorage()
    {
        _data = new List<T>();
    }

    public Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate)
    {
        lock (_lock)
        {
            return Task.FromResult(predicate == null ? _data.AsEnumerable() : _data.Where(predicate).AsEnumerable());
        }
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return GetAllAsync(null);
    }

    public Task<T> GetAsync(Func<T, bool> predicate)
    {
        lock (_lock)
        {
            return Task.FromResult(predicate == null ? _data.SingleOrDefault() : _data.Where(predicate).SingleOrDefault());
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
            var existingEntity = _data.FirstOrDefault(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                _data.Remove(existingEntity);
                _data.Add(entity);
            }
            return Task.CompletedTask;
        }
    }

    public Task DeleteAsync(int id)
    {
        lock (_lock)
        {
            var entityToRemove = _data.FirstOrDefault(e => e.Id == id);
            if (entityToRemove != null)
            {
                _data.Remove(entityToRemove);
            }
            return Task.CompletedTask;
        }
    }
}


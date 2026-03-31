using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Application.Interfaces;

/// <summary>
/// Generic base repository interface for common CRUD operations.
/// </summary>
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

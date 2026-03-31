using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Application.Interfaces;

/// <summary>
/// Product-specific repository interface, extending the base repository.
/// </summary>
public interface IProductRepository : IBaseRepository<Product>
{
    // Add product-specific queries here if needed
    // e.g. Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max);
}

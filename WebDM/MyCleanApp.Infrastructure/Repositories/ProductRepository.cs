using MyCleanApp.Application.Interfaces;
using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Infrastructure.Repositories;

/// <summary>
/// Product repository - inherits all CRUD from BaseRepository.
/// Add product-specific queries here if needed.
/// </summary>
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    // Override or add product-specific methods here
    // e.g. public async Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max)
    //          => await _dbSet.Where(p => p.Price >= min && p.Price <= max).ToListAsync();
}
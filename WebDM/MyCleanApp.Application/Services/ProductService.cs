using MyCleanApp.Application.Interfaces;
using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo; 

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<Product> CreateProductAsync(string name, decimal price)
    {
        if (price <= 0) throw new Exception("Price must be positive");

        var product = new Product { Name = name, Price = price };
        return await _repo.AddAsync(product);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _repo.GetAllAsync();
    }
}
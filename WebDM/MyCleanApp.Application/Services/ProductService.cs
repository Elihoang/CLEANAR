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
        // Domain tự enforce rule bên trong Product.Create()
        var product = Product.Create(name, price);
        return await _repo.AddAsync(product);
    }

    public async Task<List<Product>> GetAllProductsAsync()
        => await _repo.GetAllAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await _repo.GetByIdAsync(id);

    public async Task UpdateProductAsync(int id, string name, decimal price)
    {
        var product = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Product with id={id} not found.");

        // Domain method tự validate rule (price > 0, name not empty)
        product.Update(name, price);

        await _repo.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Product with id={id} not found.");

        await _repo.DeleteAsync(product.Id);
    }
}
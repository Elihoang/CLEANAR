

using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(string name, decimal price);
        Task<List<Product>> GetAllProductsAsync();
    }
}
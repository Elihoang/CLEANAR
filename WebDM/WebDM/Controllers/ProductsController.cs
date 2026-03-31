using Microsoft.AspNetCore.Mvc;
using MyCleanApp.Application.Interfaces;

namespace WebDM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, decimal price)
    {
        var product = await _service.CreateProductAsync(name, price);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _service.GetAllProductsAsync();
        return Ok(products);
    }
}
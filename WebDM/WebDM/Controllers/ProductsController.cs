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

    // GET api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllProductsAsync();
        return Ok(products);
    }

    // GET api/products/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product is null) return NotFound($"Product with id={id} not found.");
        return Ok(product);
    }

    // POST api/products
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        try
        {
            var product = await _service.CreateProductAsync(request.Name, request.Price);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request)
    {
        try
        {
            await _service.UpdateProductAsync(id, request.Name, request.Price);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteProductAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

// Request models (đặt ở đây cho tiện, dự án lớn nên tách ra folder DTOs/)
public record CreateProductRequest(string Name, decimal Price);
public record UpdateProductRequest(string Name, decimal Price);
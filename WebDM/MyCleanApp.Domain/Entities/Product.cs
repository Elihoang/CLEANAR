namespace MyCleanApp.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("Price must > 0");
        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }
}
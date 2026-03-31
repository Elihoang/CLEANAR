namespace MyCleanApp.Domain.Entities;

public class Product : BaseEntity
{
    // Private setters: chỉ cho phép thay đổi qua method của domain
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }

    // EF Core cần constructor không tham số (private để không dùng bên ngoài)
    private Product() { }

    /// <summary>
    /// Factory method: tạo Product mới, rule được enforce tại đây.
    /// </summary>
    public static Product Create(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than 0.");

        return new Product { Name = name, Price = price };
    }

    /// <summary>
    /// Cập nhật giá — rule vẫn enforce trong domain.
    /// </summary>
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("Price must be greater than 0.");
        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Cập nhật cả tên và giá (dùng cho PUT).
    /// </summary>
    public void Update(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than 0.");

        Name = name;
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }
}
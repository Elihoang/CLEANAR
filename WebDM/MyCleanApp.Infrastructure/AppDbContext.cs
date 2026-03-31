using Microsoft.EntityFrameworkCore;
using MyCleanApp.Domain.Entities;

namespace MyCleanApp.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
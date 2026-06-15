using Microsoft.EntityFrameworkCore;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Data;

public class BistroContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=bistro.db");
    }
}
using System.ComponentModel.DataAnnotations;

namespace MonAmourKiosk.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Category { get; set; } = string.Empty; // Café, Boulangerie, Bistro, Desserts
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public bool IsAvailable => StockQuantity > 0;
}
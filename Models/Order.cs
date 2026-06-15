using System.ComponentModel.DataAnnotations;

namespace MonAmourKiosk.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal Total { get; set; }
    [Required]
    public string PaymentMethod { get; set; } = string.Empty; // Carte Bancaire, QR Code, Espèces
    public List<OrderItem> OrderItems { get; set; } = new();
}
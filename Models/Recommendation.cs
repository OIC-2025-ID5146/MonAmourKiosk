using System.ComponentModel.DataAnnotations;

namespace MonAmourKiosk.Models;

public class Recommendation
{
    [Key]
    public int Id { get; set; }
    public int CoffeeId { get; set; }
    public int RecommendedProductId { get; set; }
}
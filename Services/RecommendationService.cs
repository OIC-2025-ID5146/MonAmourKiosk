using System.Linq;
using System.Collections.Generic;
using MonAmourKiosk.Data;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Services;

public class RecommendationService : IRecommendationService
{
    private readonly BistroContext _context;

    public RecommendationService(BistroContext context)
    {
        _context = context;
    }

    public List<Product> GetRecommendationsForCoffee(int coffeeId)
    {
        var recommendedIds = _context.Recommendations
            .Where(r => r.CoffeeId == coffeeId)
            .Select(r => r.RecommendedProductId)
            .ToList();

        return _context.Products
            .Where(p => recommendedIds.Contains(p.Id) && p.StockQuantity > 0)
            .ToList();
    }
}
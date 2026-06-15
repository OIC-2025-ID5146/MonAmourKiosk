using System.Collections.Generic;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Services;

public interface IRecommendationService
{
    List<Product> GetRecommendationsForCoffee(int coffeeId);
}
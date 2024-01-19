// Em um arquivo chamado ICoffeeRepository.cs

using System.Collections.Generic;
using CoffeeDrink.Models;

namespace CoffeeDrink.Repositories
{
    public interface ICoffeeRepository
    {
        List<RecommendationModel> CalculateRecommendations(List<RecevCoffeeItem> coffeeRecommendations);
    }
}

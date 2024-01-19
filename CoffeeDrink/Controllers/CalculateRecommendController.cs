using Microsoft.AspNetCore.Mvc;
using CoffeeDrink.Models;
using CoffeeDrink.Repositories;
using System.Linq;

namespace CoffeeDrink.Controllers
{
    [Route("api/v1/calculate")]
    [ApiController]
    public class CalculateRecommendController : ControllerBase
    {
        private readonly ICoffeeRepository coffeeRepository;

        public CalculateRecommendController(ICoffeeRepository coffeeRepository)
        {
            this.coffeeRepository = coffeeRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RecevCoffeeTotal coffeeModel)
        {
            if (coffeeModel == null || coffeeModel.CoffeeRecev == null || !coffeeModel.CoffeeRecev.Any())
            {
                return BadRequest("Missing or invalid coffee data");
            }

            var recommendations = coffeeRepository.CalculateRecommendations(coffeeModel.CoffeeRecev);

            var response = new
            {
                recommendations = recommendations.Select(r => new { name = r.Name, code = r.Code, wait = r.Wait })
            };

            return Ok(response);
        }
    }
}

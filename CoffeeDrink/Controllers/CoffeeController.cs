using CoffeeDrink.Models;
using Microsoft.AspNetCore.Mvc;


namespace CoffeeDrink.Controllers
{
    [Route("api/v1/coffees")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        public class ResponseModel
        {
            public List<CoffeeModelDTO> Coffees { get; set; }
        }

        [HttpGet]
        public ActionResult<ResponseModel> Get()
        {
            List<CoffeeModelDTO> coffeeModels = new List<CoffeeModelDTO>
            {
                new CoffeeModelDTO() { Name = "Black Coffe", Code = "blk"},
                new CoffeeModelDTO() { Name = "Espresso", Code = "esp"},
                new CoffeeModelDTO() { Name = "Cappuccino", Code = "cap"},
                new CoffeeModelDTO() { Name = "Latte", Code = "Lat"},
                new CoffeeModelDTO() { Name = "Flat White", Code = "wht"},
                new CoffeeModelDTO() { Name = "Cold Brew", Code = "cld"},
                new CoffeeModelDTO() { Name = "Decaf Coffee", Code = "dec"}
            };

            ResponseModel response = new ResponseModel
            {
                Coffees = coffeeModels.Select(dto => new CoffeeModelDTO { Name = dto.Name, Code = dto.Code }).ToList()
            };


            return Ok(response);
        }


    }
}

namespace CoffeeDrink.Models
{
    public class CoffeeModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Time { get; set; }
        public int? Wait { get; set; }
    }

    public class CoffeeModelDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class RecevCoffeeItem
    {
        public string Code { get; set; }
        public int Time { get; set; }
    }
    public class RecevCoffeeTotal
    {
        public List<RecevCoffeeItem> CoffeeRecev { get; set; }
    }

    public class CoffeeModelCalculate
    {
        public List<RecommendationModel> Recommendations { get; set; }
    }

    public class RecommendationModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Time { get; set; }
        public int? Wait { get; set; }
    }




}
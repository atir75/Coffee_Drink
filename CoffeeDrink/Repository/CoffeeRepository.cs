using CoffeeDrink.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeDrink.Repositories
{
    

    public class CoffeeRepository : ICoffeeRepository
    {
        public List<RecommendationModel> CalculateRecommendations(List<RecevCoffeeItem> coffeeRecommendations)
        {
            List<RecommendationModel> recommendations = new List<RecommendationModel>();

            foreach (var recommendation in coffeeRecommendations)
            {
                string code = recommendation.Code;
                int time = recommendation.Time;

                int caffeineLevel = 0;
                string name = "";
                int? wait = time / 2;

                switch (code.ToLower())
                {
                    case "blk":
                        caffeineLevel = 95;
                        name = "Cappuccino";
                        code = "cap";
                        break;
                    case "esp":
                        caffeineLevel = 63;
                        name = "Latte";
                        code = "lat";
                        break;
                    case "cap":
                        caffeineLevel = 63;
                        name = "Black coffee";
                        code = "blk";
                        break;
                    case "lat":
                        caffeineLevel = 63;
                        name = "Flat White";
                        code = "wht";
                        break;
                    case "wht":
                        caffeineLevel = 63;
                        name = "Black coffee";
                        code = "blk";
                        break;
                    case "cld":
                        caffeineLevel = 120;
                        name = "Decaf coffee";
                        code = "dec";
                        break;
                    case "dec":
                        caffeineLevel = 7;
                        name = "Cold brew";
                        code = "cld";
                        break;
                }

                recommendations.Add(new RecommendationModel
                {
                    Name = name,
                    Code = code,
                    Wait = (int)wait
                });

                string secondCode = GetSecondCode(code);
                if (caffeineLevel >= 150)
                {
                    name = "Cappuccino";
                    secondCode = "cap";
                    wait = 60;
                }
                else if (caffeineLevel >= 90)
                {
                    name = "Black Coffee";
                    secondCode = "blk";
                    wait = 30;
                }
                else if (caffeineLevel >= 30)
                {
                    name = "Cold brew";
                    secondCode = "cld";
                    wait = 30;
                }

                recommendations.Add(new RecommendationModel
                {
                    Name = name,
                    Code = secondCode,
                    Wait = (int)wait
                });

            }

            return recommendations;
        }

        private string GetSecondCode(string firstCode)
        {
            return firstCode + "_second";
        }

        private int CalculateWaitTime(int caffeineLevel)
        {
            if (caffeineLevel >= 150)
            {
                return 60;
            }
            else if (caffeineLevel >= 90)
            {
                return 30;
            }
            else if (caffeineLevel >= 30)
            {
                return 30;
            }

            return 0;
        }

    }

    public class RecommendationModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Wait { get; set; }
    }
}

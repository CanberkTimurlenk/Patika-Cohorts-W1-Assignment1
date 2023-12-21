using Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Models;

namespace Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Db
{
    public static class SampleDb
    {
        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product(){Id = 1, Name = "FuseTea", CategoryId=1, Price = 38.00M },
            new Product(){Id = 2, Name = "Lemonade", CategoryId=1, Price = 193.00M }
        };

        public static List<Category> Categories { get; set; } = new List<Category>()
        {
            new Category() { Id =1, Name = "Beverages" }
        };

    }
}

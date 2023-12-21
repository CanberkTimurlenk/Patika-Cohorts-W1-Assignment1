using System.ComponentModel.DataAnnotations;

namespace Patika_Akbank_NET_Bootcamp_Cohorts_Week_1_Homework_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

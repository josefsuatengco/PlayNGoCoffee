using System.ComponentModel.DataAnnotations;

namespace PlayNGoCoffee
{
    public class CoffeeDataModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string CoffeeName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
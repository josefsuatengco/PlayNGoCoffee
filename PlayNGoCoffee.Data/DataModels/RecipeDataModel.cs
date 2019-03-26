using System.ComponentModel.DataAnnotations;

namespace PlayNGoCoffee
{
    public class RecipeDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
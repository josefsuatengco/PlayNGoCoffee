using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoCoffee
{
    public class RecipeDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
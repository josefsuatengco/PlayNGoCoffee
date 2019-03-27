using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoCoffee
{
    public class RecipeIngredientDataModel
    {
        [Required]
        public int RecipeId { get; set; }
        
        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int Unit { get; set; }

        public RecipeDataModel Recipe { get; set; }

        public IngredientDataModel Ingredient { get; set; }

    }
}
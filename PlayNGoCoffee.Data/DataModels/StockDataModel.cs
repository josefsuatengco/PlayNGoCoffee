using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoCoffee
{
    public class StockDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int Unit { get; set; }

        [Required]
        public int LocationId { get; set; }
        
        
        public IngredientDataModel Ingredient { get; set; }
    }
}

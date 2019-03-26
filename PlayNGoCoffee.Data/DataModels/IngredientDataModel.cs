using System.ComponentModel.DataAnnotations;

namespace PlayNGoCoffee
{
    public class IngredientDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string IngredientName { get; set; }
        
        [Required]
        public int Stock { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}

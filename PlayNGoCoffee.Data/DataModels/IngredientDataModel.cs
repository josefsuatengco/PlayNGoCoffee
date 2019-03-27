using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoCoffee
{
    public class IngredientDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

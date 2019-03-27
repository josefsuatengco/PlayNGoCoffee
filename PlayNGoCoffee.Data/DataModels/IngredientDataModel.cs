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
        public int CoffeeBeanStock { get; set; }
        
        [Required]
        public int MilkStock { get; set; }
        
        [Required]
        public int SugarStock { get; set; }

        [Required]
        public int LocationId { get; set; }
    }
}

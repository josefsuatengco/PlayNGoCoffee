using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNGoCoffee
{
    public class OrderHistoryDataModel

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int RecipeId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }

        [Required]
        public int Quantity { get; set; }


        public RecipeDataModel Recipe { get; set; }
    }
}

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
        [MaxLength(50)]
        public string CoffeeName { get; set; }

        [Required]
        public int CoffeeId { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }
    }
}

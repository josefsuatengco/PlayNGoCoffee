using System.ComponentModel.DataAnnotations;

namespace PlayNGoCoffee
{
    public class LocationDataModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocationName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}

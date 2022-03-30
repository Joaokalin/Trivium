using System.ComponentModel.DataAnnotations;

namespace TriviumApi.Models.DTOS
{
    public class ProductDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}

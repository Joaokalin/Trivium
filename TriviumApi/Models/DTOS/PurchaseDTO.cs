using System.ComponentModel.DataAnnotations;

namespace TriviumApi.Models.DTOS
{
    public class PurchaseDTO
    {
        [Required]
        public int CustomerId { get; set; }
    }
}

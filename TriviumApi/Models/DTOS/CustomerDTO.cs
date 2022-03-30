using System.ComponentModel.DataAnnotations;
using TriviumApi.Models.Entities.Customers;

namespace TriviumApi.Models.DTOS
{
    public class CustomerDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public Customer Map() => new Customer
        {
            Name = Name,
            Phone = Phone,
            Address = Address
        };
    }
}

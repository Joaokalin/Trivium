using System.ComponentModel.DataAnnotations.Schema;
using TriviumApi.Models.Entities.Products;

namespace TriviumApi.Models.Entities.Purchases
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        [ForeignKey("Purchase")]
        public virtual int PurchaseId { get; set; }

        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}

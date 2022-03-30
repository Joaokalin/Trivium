using TriviumApi.Models.Entities.Customers;

namespace TriviumApi.Models.Entities.Purchases
{
    public class Purchase
    {
        public int Id{ get; set; }

        public int CustomerId { get; set; }

        public virtual IList<PurchaseItem> PurchaseItens { get; set; }

    }
}

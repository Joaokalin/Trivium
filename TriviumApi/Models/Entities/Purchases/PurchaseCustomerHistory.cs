namespace TriviumApi.Models.Entities.Purchases
{
    public class PurchaseCustomerHistory
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public  IList<PurchaseItem> PurchaseItens { get; set; }

        public double Amount { get; set; }

        public static PurchaseCustomerHistory Map(Purchase purchase) => new PurchaseCustomerHistory
        {
            Id = purchase.Id,
            CustomerId = purchase.CustomerId,
            PurchaseItens = purchase.PurchaseItens,
            Amount = purchase.PurchaseItens.Sum(item => item.Quantity * item.Product.Price)
        };

    }
}

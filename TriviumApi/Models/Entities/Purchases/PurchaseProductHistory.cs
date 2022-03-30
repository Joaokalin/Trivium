namespace TriviumApi.Models.Entities.Purchases
{
    public class PurchaseProductHistory
    {

        public int Quantity { get; set; }
        public double Amount { get; set; }

        public static PurchaseProductHistory Map(List<PurchaseItem> purchaseItens) => new PurchaseProductHistory
        {
            Quantity = purchaseItens.Sum(item => item.Quantity),
            Amount = purchaseItens.Sum(item => item.Quantity * item.Product.Price)
        };
    }
}

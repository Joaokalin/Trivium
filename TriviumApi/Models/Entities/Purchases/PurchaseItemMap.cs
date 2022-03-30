using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriviumApi.Models.Entities.Products;

namespace TriviumApi.Models.Entities.Purchases
{
    public static class PurchaseItemMap
    {
        public static void Map(this EntityTypeBuilder<PurchaseItem> entity)
        {
            entity.ToTable("PurchaseItem");

            entity.HasKey(prop => prop.Id);
            entity.Property(prop => prop.Quantity).IsRequired();
        }
    }
}
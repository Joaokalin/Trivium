using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TriviumApi.Models.Entities.Customers;

namespace TriviumApi.Models.Entities.Purchases
{
    public static class PurchaseMap
    {
        public static void Map(this EntityTypeBuilder<Purchase> entity)
        {
            entity.ToTable("Purchase");

            entity.HasKey(prop => prop.Id);
            entity.HasOne<Customer>().WithMany().HasForeignKey(prop => prop.CustomerId);
        }
    }
}
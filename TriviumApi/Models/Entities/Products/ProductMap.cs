using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TriviumApi.Models.Entities.Products
{
    public static class ProductMap
    {
        public static void Map(this EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");

            entity.HasKey(prop => prop.Id);
            entity.Property(prop => prop.Name).IsRequired();
            entity.Property(prop => prop.Price).IsRequired();

        }
    }
}
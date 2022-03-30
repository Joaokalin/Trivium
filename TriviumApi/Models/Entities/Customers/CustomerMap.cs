using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TriviumApi.Models.Entities.Customers
{
    public static class CustomerMap
    {
        public static void Map(this EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Customer");

            entity.HasKey(prop => prop.Id);
            entity.Property(prop => prop.Name).IsRequired();
            entity.Property(prop => prop.Phone).IsRequired();
            entity.Property(prop => prop.Address).IsRequired();

        }
    }
}
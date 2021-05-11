using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired().HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired().HasMaxLength(500);

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.Property(p => p.ProductUrl).IsRequired();

            builder.HasOne(x => x.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(x => x.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);

        }
    }
}

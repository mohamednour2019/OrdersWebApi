using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Domain.Entities;
using Orders.Infrastructure.Seed;


namespace Orders.Infrastructure.EntitiesConfigurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", schema: "dbo");
            builder.HasKey(x => x.Id).IsClustered(false);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasIndex(x => x.ProductName).IsUnique();
            builder.SeedProductsData();
        }
    }
}

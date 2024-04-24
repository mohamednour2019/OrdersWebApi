using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Domain.Entities;
using Orders.Infrastructure.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.EntitiesConfigurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct", schema: "dbo");
            builder.Property(x => x.OrderId).ValueGeneratedNever();
            builder.Property(x=>x.ProductId).ValueGeneratedNever();
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.OrderId, x.ProductId }).IsClustered(false);
            builder.HasOne(x => x.Order).WithMany(o => o.OrderProduct).HasForeignKey(x=>x.OrderId);
            builder.HasOne(x =>x.Product).WithMany(p=>p.OrderProduct).HasForeignKey(x=>x.ProductId);
            //builder.SeedOrderProductData();
        }
    }
}

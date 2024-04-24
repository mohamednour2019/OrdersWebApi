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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configure Order's Table 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", schema: "dbo");
            builder.HasKey(x => x.Id).IsClustered(false);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            //builder.SeedOrdersData();

        }
    }
}

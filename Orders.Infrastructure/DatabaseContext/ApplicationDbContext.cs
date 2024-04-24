using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Orders.Core.Domain.Entities;
using Orders.Infrastructure.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderProduct> OrderProduct {  get; set; }


        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration= configuration;
        }


        /// <summary>
        /// configure dbcontext options and connection string to db
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string ConnectionString = _configuration.GetConnectionString("Default")!;
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        /// <summary>
        /// confiugre model creation and entities configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

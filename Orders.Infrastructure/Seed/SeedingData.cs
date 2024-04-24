using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Seed
{
    public static  class SeedingData
    {
        public static DateTime NowDate= DateTime.Now;
        public static void SeedOrdersData(this EntityTypeBuilder<Order> modelBuilder)
        {
            modelBuilder.HasData(new List<Order>()
            {
                new Order()
                {
                    Id=new Guid("{1B58633E-670A-413F-B6B8-7D756FFA28A6}"),
                    CustomerName="TestName",
                    OrderDate=NowDate,
                    OrderNumber="2024_1",
                    TotalAmount=222
                },
                new Order()
                {
                    Id=new Guid("{5EA3C61E-24F0-4B8D-BAF0-579A34D4A317}"),
                    CustomerName="TestName2",
                    OrderDate=NowDate,
                    OrderNumber="2024_2",
                    TotalAmount=333
                }

            });
        }

        public static void SeedProductsData(this EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.HasData(new List<Product>() {
                new Product()
                {
                    Id=new Guid("{C52611F0-D410-45BE-AAEF-A37E58F7B47D}"),
                    ProductName="Tomatoes",
                    UnitPrice=50,
                },
                new Product()
                {
                    Id=new Guid("{4D47BFB2-17AF-49DD-981B-6D3D6A5A7904}"),
                    ProductName="Botatoes",
                    UnitPrice=20
                },
                new Product()
                {
                    Id=new Guid("{D1069EBF-28E1-4D28-B216-57604BA6FC1C}"),
                    ProductName="Carrot",
                    UnitPrice=30
                }
            }) ;
        }

        public static void SeedOrderProductData(this EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasData(new List<OrderProduct>()
            {
                new OrderProduct()
                {
                    OrderId=new Guid("{1B58633E-670A-413F-B6B8-7D756FFA28A6}"),
                    ProductId=new Guid("{C52611F0-D410-45BE-AAEF-A37E58F7B47D}"),
                    Quantity=3,
                    TotalPrice=150
                },
                new OrderProduct()
                {
                    OrderId=new Guid("{1B58633E-670A-413F-B6B8-7D756FFA28A6}"),
                    ProductId=new Guid("{4D47BFB2-17AF-49DD-981B-6D3D6A5A7904}"),
                    Quantity=4,
                    TotalPrice=100
                },
                new OrderProduct()
                {
                    OrderId=new Guid("{5EA3C61E-24F0-4B8D-BAF0-579A34D4A317}"),
                    ProductId=new Guid("{C52611F0-D410-45BE-AAEF-A37E58F7B47D}"),
                    Quantity=3,
                    TotalPrice=150
                }

            });
        }
    }
}

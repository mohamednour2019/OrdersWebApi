using AutoMapper;
using Microsoft.Data.SqlClient;
using Orders.Core.Domain.Entities;
using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            Initialize();
        }
        public void Initialize()
        {
            CreateMap<OrderRequestDto, Order>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName));

            CreateMap<ProductDetailsRequestDto, ProductDetailsResponseDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Product, ProductDetailsResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<(Product,ProductDetailsRequestDto), ProductDetailsResponseDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Item2.Quantity))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Item1.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Item1.UnitPrice))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Item1.Id));

            CreateMap<ProductDetailsRequestDto, OrderProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, OrderProduct>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductDetailsResponseDto, OrderProduct>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<(ProductDetailsRequestDto, Order, ProductDetailsResponseDto), OrderProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Item1.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Item1.Quantity))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Item2.Id))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Item3.TotalPrice));

            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));


            CreateMap<ProductRequestDto, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<OrderProduct, ProductDetailsResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.UnitPrice))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<AddOrderProductRequestDto, OrderProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantatiy));

            //CreateMap<OrderProduct,Product>()
            //    .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.ProductId))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))

        }
    }
}

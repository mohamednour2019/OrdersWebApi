using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.Services;
using Orders.Core.Services.OrdersServices.AddOrdersServices;
using Orders.Core.Services.OrdersServices.DeleteOrdersServices;
using Orders.Core.Services.OrdersServices.GetOrdersServices;
using Orders.Core.Services.OrdersServices.UpdateOrdersServices;
using Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts;
using Orders.Core.ServicesContracts.OrdersServicesContracts.UpdateOrdersServicesContracts;
using Orders.Infrastructure.DatabaseContext;
using Orders.Infrastructure.Repositories;
using Serilog;


namespace Orders.Presentation.API.ServicesConfiguration
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection Services) {
            //register services to ioc container
             Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
             Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
             Services.AddScoped<IGenericRepository<OrderProduct>, GenericRepository<OrderProduct>>();
             Services.AddScoped<IAddOrderService, AddOrderService>();
             Services.AddScoped<IAddProductService, AddProductService>();
             Services.AddScoped<IGetOrdersService, GetOrdersService>();
             Services.AddScoped<IOrdersRepository, OrdersRepository>();
             Services.AddScoped<IGetOrderByIdService, GetOrderByIdService>();
             Services.AddScoped<IUpdateOrderService, UpdateOrderService>();
             Services.AddScoped<IDeleteOrderService, DeleteOrderService>();
             Services.AddScoped<IGetOrderItemService, GetOrderItemService>();
             Services.AddScoped<IGetOrderItemsService, GetOrderItemsService>();
             Services.AddScoped<IAddOrderProductService, AddOrderProductService>();
             Services.AddScoped<IUpdateOrderItemService, UpdateOrderItemService>();
             Services.AddScoped<IDeleteOrderItemService, DeleteOrderItemService>();
             Services.AddTransient<IUnitOfWork, UnitOfWork>();
             Services.AddDbContext<ApplicationDbContext>();

             Services.AddAutoMapper(typeof(Orders.Infrastructure.Mapper.AutoMapper));

            Services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json"));
            }).AddXmlSerializerFormatters();


            Services.AddEndpointsApiExplorer();//get endpoints metadata
            //generate swagger.json file for each version
            Services.AddSwaggerGen(c =>
            {
                // Define Swagger document for version 1
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order API v1", Version = "v1" });

                //// Define Swagger document for version 2
                //c.SwaggerDoc("v2", new OpenApiInfo { Title = "Order API v2", Version = "v2" });
            });
            //specify builder of version with it's configuraions
            Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            return Services;
        }

        public static ConfigureHostBuilder ConfigureHosts(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider serviceProvider, LoggerConfiguration logger) =>
            {
                logger.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(serviceProvider);
            });
            return builder.Host;
        }
    }
}

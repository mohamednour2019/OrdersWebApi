using Orders.Core.Domain.Entities;
using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Domain.Extensions
{
    public static class OrderRequestDtoExtension
    {
        public static int _counter = 0;
        static OrderRequestDtoExtension()
        {
            _counter++;
        }
        public static Order ToOrder(this OrderRequestDto orderRequestDto)
        {
            return new Order()
            {
                CustomerName = orderRequestDto.CustomerName,
                OrderDate = DateTime.Now,
                OrderNumber = $"{DateTime.Now.Year.ToString()}_{_counter.ToString()}",
                Id = Guid.NewGuid(),
                TotalAmount = 0
            };
        }
    }
}

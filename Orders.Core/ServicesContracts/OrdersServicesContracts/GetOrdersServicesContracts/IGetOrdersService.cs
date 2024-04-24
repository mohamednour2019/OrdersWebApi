using Orders.Core.Domain.Entities;
using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts
{
    public interface IGetOrdersService : IGenericService<OrderRequestDto, List<OrderResponseDto>>
    {
        //Task<List<OrderResponseDto>> GetOrdersAsync();
    }
}

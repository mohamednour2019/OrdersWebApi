using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.UpdateOrdersServicesContracts
{
    public interface IUpdateOrderItemService : IGenericService<UpdateOrderItemRequestDto, ProductDetailsResponseDto>
    {
        //Task<ProductDetailsResponseDto>UpdateOrderItem(Guid orderId,Guid productId,UpdateOrderItemRequestDto requestDto);
    }
}

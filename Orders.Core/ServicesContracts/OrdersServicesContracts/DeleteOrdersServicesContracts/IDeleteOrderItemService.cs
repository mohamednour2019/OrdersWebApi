using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts
{
    public interface IDeleteOrderItemService : IGenericService<DeleteOrderItemRequestDto, bool>
    {
        //Task<bool> DeleteOrderItem(Guid orderId, Guid productId);
    }
}

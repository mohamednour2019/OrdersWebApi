using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.DeleteOrdersServicesContracts
{
    public interface IDeleteOrderService : IGenericService<Guid, bool>
    {
        //Task<bool> DeleteOrder(Guid id);
    }
}

using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts
{
    public interface IAddProductService:IGenericService<ProductRequestDto, ProductResponseDto>
    {
    }
}

using Orders.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.ServicesContracts.OrdersServicesContracts.AddOrdersServicesContracts
{
    public interface IAddOrderProductService : IGenericService<AddOrderProductRequestDto, ProductDetailsResponseDto>
    {
        //Task<ProductDetailsResponseDto> AddProductToOrder(AddOrderProductRequestDto requestDto);
    }
}

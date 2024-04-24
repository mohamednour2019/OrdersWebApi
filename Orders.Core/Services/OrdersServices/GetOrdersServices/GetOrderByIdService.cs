using AutoMapper;
using Orders.Core.Domain.Entities;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO_s;
using Orders.Core.ServicesContracts.OrdersServicesContracts.GetOrdersServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Core.Services.OrdersServices.GetOrdersServices
{
    public class GetOrderByIdService : IGetOrderByIdService
    {
        private IOrdersRepository _repository;
        private IMapper _mapper;
        public GetOrderByIdService(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //public async Task<OrderResponseDto> GetOrderById(Guid id)
        //{
        //    Order order = await _repository.getOrderById(id)!;
        //    if (order is null)
        //        return null;
        //    OrderResponseDto response= _mapper.Map<OrderResponseDto>(order);
        //    response.ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(order.OrderProduct);
        //    return response;

        //}

        public async Task<OrderResponseDto> performService(Guid id)
        {
            Order order = await _repository.getOrderById(id)!;
            if (order is null)
                return null;
            OrderResponseDto response = _mapper.Map<OrderResponseDto>(order);
            response.ProductsDetails = _mapper.Map<List<ProductDetailsResponseDto>>(order.OrderProduct);
            return response;
        }
    }
}
